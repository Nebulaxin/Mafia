using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DayLoopVoteRepeat : MonoBehaviour
{
    public TMP_Text TimerTMP;
    public TMP_Text NameOfPlayerTMP;
    public GameObject VoteButtonPrefab;
    public Transform Scroll;
    public static float SeconsLeft = Menu.TalkTime;
    [SerializeField] public static GameObject NextButton;
    public static int i;
    public static int max = 0;
    public static int numOfVoted = 0;
    public static int[] indexesVotedOld;
    public static int[] indexesVotedNew;

    private GameObject InstantiatedGameObject;
    private GameObject HiddenButton;
    private float PositionOfPrefabY;
    private float PositionOfPrefabX;
    private float WidthOfPrefab = 1000;
    private float HeightOfPrefab = 150;
    private float Margin = Screen.height / 10.10526315789474f;
    private bool takingAway;
    private bool continueVoting;

    void Start()
    {
        max = 0;
        SeconsLeft = Menu.TalkTime;
        takingAway = false;
        NextButton = GameObject.FindGameObjectWithTag("NextButton");
        PositionOfPrefabX = TimerTMP.transform.position.x;
        PositionOfPrefabY = TimerTMP.transform.position.y;
        RectTransform rtTimer = (RectTransform)TimerTMP.transform;
        TimerTMP.text = SeconsLeft.ToString();
        for (int i = 0; i < Menu.NumberOfPlayers; i++)
        {
            DayLoopVoteRepeat.indexesVotedOld[i] = DayLoopVoteRepeat.indexesVotedNew[i];
            DayLoopVoteRepeat.indexesVotedNew[i] = -1;
            Debug.Log("DayLoopVoteRepeat.indexesVotedOld[i] " + DayLoopVoteRepeat.indexesVotedOld[i]);
            Debug.Log("DayLoopVoteRepeat.indexesVotedNew[i] " + DayLoopVoteRepeat.indexesVotedNew[i]);
        }
        Check.AliveColumn();
        NameOfPlayerTMP.text = Player.PlayersArray[Menu.column].nic + ", choose the Player to vote for";
        
            for (i = 0; i < DayLoopVoteRepeat.numOfVoted; i++)
            {
                if (indexesVotedOld[i] != -1)
                {
                    PositionOfPrefabY -= Margin;
                    InstantiatedGameObject = Instantiate(VoteButtonPrefab, new Vector3(PositionOfPrefabX, PositionOfPrefabY, 0), Quaternion.identity);
                    InstantiatedGameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, WidthOfPrefab);
                    InstantiatedGameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, HeightOfPrefab);
                    InstantiatedGameObject.transform.SetParent(Scroll);
                    InstantiatedGameObject.name = indexesVotedOld[i].ToString();
                    InstantiatedGameObject.GetComponentInChildren<TMP_Text>().text = Player.PlayersArray[indexesVotedOld[i]].nic.ToString();
                    InstantiatedGameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                }
            }
        numOfVoted = 0;
        HiddenButton = GameObject.Find(Menu.column.ToString());
        if (HiddenButton != null)
        {
            HiddenButton.SetActive(false);
        }
        Debug.Log("Margin " + Margin);
    }

    void Update()
    {
        if (!takingAway && SeconsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }
    IEnumerator TimerTake()
    {
        takingAway = true;
        SeconsLeft -= 1;
        yield return new WaitForSeconds(1);
        if (SeconsLeft <= 0)
        {
            Next();
        }
        TimerTMP.text = SeconsLeft.ToString();
        takingAway = false;
    }

    public void Next()
    {
        SeconsLeft = Menu.TalkTime;
        if (Menu.column != Menu.NumberOfPlayers)
        {
            if (HiddenButton != null)
            {
                HiddenButton.SetActive(true);
            }
        }
        ++Menu.column;
        Check.AliveColumn();
        if (DayLoopVote.IndexVotedPlayer != null)
        {
            Player.PlayersArray[Convert.ToInt32(DayLoopVote.IndexVotedPlayer)].votes += 1;
            ArrayToConsole.Output("DayLoopVote Upate()");
            DayLoopVote.IndexVotedPlayer = null;
        }
        if (Menu.column != Menu.NumberOfPlayers)
        {
            HiddenButton = GameObject.Find(Menu.column.ToString());
            if (HiddenButton != null)
            {
                HiddenButton.SetActive(false);
            }
            SeconsLeft = Menu.TalkTime;
            NameOfPlayerTMP.text = Player.PlayersArray[Menu.column].nic + ", choose the Player to vote for";
            TimerTMP.text = SeconsLeft.ToString();
        }
        else
        {
            SeconsLeft = Menu.TalkTime;
            DayLoopVote.numOfVoted = numOfVoted;
            ArrayToConsole.Output("DayLoopVote");
            for (int i = 0; i < Menu.NumberOfPlayers; i++)
            {
                if (max < Player.PlayersArray[i].votes)
                {
                    max = Player.PlayersArray[i].votes;
                }
            }
            if (max != 0)
            {
                for (int i = 0; i < Menu.NumberOfPlayers; i++)
                {
                    if (Player.PlayersArray[i].votes == max)
                    {
                        indexesVotedNew[numOfVoted] = i;
                        Debug.Log("indexes[] = " + i);
                        numOfVoted++;
                    }
                }
            }
            Debug.Log("DayLoopVote.numOfVoted " + DayLoopVote.numOfVoted);
            Menu.column = 0;
            Player.ClearVotes();
            if (numOfVoted == 0)
            {
                SceneManager.LoadScene("DiedPlayers");
            }
            if (numOfVoted == 1)
            {
                Player.PlayersArray[indexesVotedNew[0]].status = status.die;
                Debug.Log("indexesVotedNew[0] " + indexesVotedNew[0]);
                SceneManager.LoadScene("DiedPlayers");
            }
            if (numOfVoted > 1)
            {
                continueVoting = false;
                for (int i = 0; i < indexesVotedNew.Length; i++)
                {
                    Debug.Log("indexesVotedOld[" + i + "] = " + indexesVotedOld[i] + " indexesVotedNew[" + i + "] = " + indexesVotedNew[i]);
                    if (indexesVotedOld[i] != indexesVotedNew[i])
                    {
                        continueVoting = true;
                    }
                }
                if (continueVoting)
                {
                    SceneManager.LoadScene("RepeatVote");
                    return;
                }
                else
                {
                    /*for (int i = 0; i < numOfVoted; i++)
                    {
                        Player.PlayersArray[indexesVotedNew[i]].status = status.die;
                    }*/
                    SceneManager.LoadScene("DiedPlayers");
                    return;
                }
            }
        }
    }
}