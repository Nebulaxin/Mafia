using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DayLoopVote : MonoBehaviour
{
    public TMP_Text TimerTMP;
    public TMP_Text NameOfPlayerTMP;
    public GameObject VoteButtonPrefab;
    public Transform Scroll;
    public static GameObject NextButton;
    public static float SeconsLeft = Menu.TalkTime;
    public static int? IndexVotedPlayer;
    public static int i;
    public static int max = 0;
    public static int numOfVoted = 0;

    private GameObject InstantiatedGameObject;
    private GameObject HiddenButton;
    private float PositionOfPrefabY;
    private float PositionOfPrefabX;
    private float WidthOfPrefab = 1000;
    private float HeightOfPrefab = 150;
    private float Margin = Screen.height / 10.10526315789474f;
    private bool takingAway;

    void Start()
    {
        max = 0;
        numOfVoted = 0;
        SeconsLeft = Menu.TalkTime;
        takingAway = false;
        NextButton = GameObject.FindGameObjectWithTag("NextButton");
        PositionOfPrefabX = TimerTMP.transform.position.x;
        PositionOfPrefabY = TimerTMP.transform.position.y;
        RectTransform rtTimer = (RectTransform)TimerTMP.transform;
        TimerTMP.text = SeconsLeft.ToString();
        Check.AliveColumn();
        NameOfPlayerTMP.text = Player.PlayersArray[Menu.column].nic + ", choose the Player to vote for";
        Debug.Log("Margin " + Margin);
        
            for (i = 0; i < Menu.NumberOfPlayers; i++)
            {
                Check.AliveI();
                if (i < Menu.NumberOfPlayers)
                {
                    PositionOfPrefabY -= Margin;
                    InstantiatedGameObject = Instantiate(VoteButtonPrefab, new Vector3(PositionOfPrefabX, PositionOfPrefabY, 0), Quaternion.identity);
                    InstantiatedGameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, WidthOfPrefab);
                    InstantiatedGameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, HeightOfPrefab);
                    InstantiatedGameObject.transform.SetParent(Scroll);
                    InstantiatedGameObject.name = i.ToString();
                    InstantiatedGameObject.GetComponentInChildren<TMP_Text>().text = Player.PlayersArray[i].nic.ToString();
                    //InstantiatedGameObject.gameObject.transform.localScale = new Vector3(1, 1, 1);
                    InstantiatedGameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                }
            }
        HiddenButton = GameObject.Find(Menu.column.ToString());
        HiddenButton.SetActive(false);
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
            HiddenButton.SetActive(true);
        }
        ++Menu.column;
        Check.AliveColumn();

        if (IndexVotedPlayer != null)
        {
            Player.PlayersArray[Convert.ToInt32(IndexVotedPlayer)].votes += 1;
            ArrayToConsole.Output("DayLoopVote Upate()");
            IndexVotedPlayer = null;
        }
        if (Menu.column != Menu.NumberOfPlayers)
        {
            HiddenButton = GameObject.Find(Menu.column.ToString());
            HiddenButton.SetActive(false);
            SeconsLeft = Menu.TalkTime;
            NameOfPlayerTMP.text = Player.PlayersArray[Menu.column].nic + ", choose the Player to vote for";
            TimerTMP.text = SeconsLeft.ToString();
        }
        else
        {
            SeconsLeft = Menu.TalkTime;
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
                        DayLoopVoteRepeat.indexesVotedNew[numOfVoted] = i;
                        Debug.Log("indexes[] = " + i);
                        numOfVoted++;
                    }
                }
            }
            Debug.Log("numOfVoted " + numOfVoted);
            Menu.column = 0;
            Player.ClearVotes();
            if (numOfVoted == 0)
            {
                SceneManager.LoadScene("DiedPlayers");
            }
            else if (numOfVoted == 1)
            {
                Player.PlayersArray[DayLoopVoteRepeat.indexesVotedNew[0]].status = status.die;
                SceneManager.LoadScene("DiedPlayers");
            }
            else if (numOfVoted > 1)
            {
                DayLoopVoteRepeat.numOfVoted = numOfVoted;
                SceneManager.LoadScene("RepeatVote");
            }
        }
    }
}