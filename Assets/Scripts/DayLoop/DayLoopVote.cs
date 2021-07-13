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
    public static float SeconsLeft = Menu.TalkTime;
    public static GameObject NextButton;
    public static int? IndexVotedPlayer;
    public static int i;
    public static int max = 0;
    public static int numOfVoted = 0;
    public static int[] indexes = new int[Menu.NumberOfPlayers];

    private GameObject InstantiatedGameObject;
    private GameObject MainCamera;
    private Transform Canvas;
    private float PositionOfPrefabY;
    private float PositionOfPrefabX;
    private float WidthOfPrefab = 1000;
    private float HeightOfPrefab = 150;
    private float Margin = Screen.height / 10.10526315789474f;

    void Start()
    {
        max = 0;
        numOfVoted = 0;
        indexes = new int[Menu.NumberOfPlayers];
        Check.AliveColumn();
        NameOfPlayerTMP.text = Player.PlayersArray[Menu.column].nic + ", выберите игрока, за которого проголосуете";
        NextButton = GameObject.FindGameObjectWithTag("NextButton");
        Canvas = GameObject.Find("Canvas").transform;
        RectTransform rtTimer = (RectTransform)TimerTMP.transform;
        PositionOfPrefabX = TimerTMP.transform.position.x;
        PositionOfPrefabY = TimerTMP.transform.position.y;
        Debug.Log("Margin " + Margin);

        for (i = 0; i < Menu.NumberOfPlayers; i++)
        {
            Check.AliveI();
            if (i < Menu.NumberOfPlayers)
            {
                PositionOfPrefabY -= Margin;
                InstantiatedGameObject = Instantiate(VoteButtonPrefab, new Vector3(PositionOfPrefabX, PositionOfPrefabY, 0), Quaternion.identity);
                InstantiatedGameObject.transform.SetParent(GameObject.Find("Canvas").transform);
                InstantiatedGameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, WidthOfPrefab);
                InstantiatedGameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, HeightOfPrefab);
                InstantiatedGameObject.name = i.ToString();
                InstantiatedGameObject.GetComponentInChildren<TMP_Text>().text = Player.PlayersArray[i].nic.ToString();
                //InstantiatedGameObject.gameObject.transform.localScale = new Vector3(1, 1, 1);
                InstantiatedGameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }
    }
    void Update()
    {
        if (SeconsLeft > 0)
        {
            SeconsLeft -= Time.deltaTime;
            TimerTMP.text = Convert.ToString(Convert.ToInt32(SeconsLeft));
        }
        if (SeconsLeft <= 0)
        {
            ++Menu.column;
            Check.AliveColumn();
            if (IndexVotedPlayer != null)
            {
                Player.PlayersArray[Convert.ToInt32(IndexVotedPlayer)].votes += 1;
                ArrayToConsole.Output("DayLoopVote Upate()");
                Debug.Log("Not empty");
                IndexVotedPlayer = null;
            }
            if (Menu.column != Menu.NumberOfPlayers)
            {
                SeconsLeft = Menu.TalkTime;
                NameOfPlayerTMP.text = Player.PlayersArray[Menu.column].nic + ", выберите игрока, за которого проголосуете";
            }
            else
            {
                SeconsLeft = Menu.TalkTime;
                ArrayToConsole.Output("FindDiedPlayer");
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
                            indexes[numOfVoted] = i;
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
                if (numOfVoted == 1)
                {
                    Player.PlayersArray[indexes[0]].status = "die";
                    SceneManager.LoadScene("DiedPlayers");
                }
                if (numOfVoted > 1)
                {
                    if (RepeatVote.RepeartVote)
                    {
                        RepeatVote.RepeartVote = false;
                        for (int i = 0; i < numOfVoted; i++)
                        {
                            Player.PlayersArray[indexes[i]].status = "die";
                        }
                        SceneManager.LoadScene("DiedPlayers");
                    }
                    else
                    {
                        SceneManager.LoadScene("RepeatVote");
                    }
                }
            }
        }
    }
}