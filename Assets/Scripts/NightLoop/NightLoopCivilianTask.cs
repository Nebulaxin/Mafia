using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NightLoopCivilianTask : MonoBehaviour
{
    public GameObject thisAnswerButton;
    public GameObject nextButton;
    public GameObject answerButtonPrefab;
    public Transform panel;
    public TMP_Text taskText;
    public static int RightAnswer;

    private int firstTerm;
    private int secondTerm;
    private int indexRightAnswerButton;


    private void Start()
    {
        nextButton.SetActive(false);
        System.Random random = new System.Random();
        firstTerm = random.Next(15);
        secondTerm = random.Next(15);
        indexRightAnswerButton = random.Next(4);
        RightAnswer = firstTerm + secondTerm;
        taskText.text = firstTerm.ToString() + " + " + secondTerm.ToString() + " =";
        for (int i = 0; i < 4; i++)
        {
            thisAnswerButton = GameObject.Find("AnswerButton" + i);
            if (i == indexRightAnswerButton)
            {
                thisAnswerButton.GetComponentInChildren<TMP_Text>().text = RightAnswer.ToString();
            }
            else
            {
                thisAnswerButton.GetComponentInChildren<TMP_Text>().text = random.Next(30).ToString();
            }
        }
    }
    public void Next()
    {
        ++Menu.column;
        Check.AlivePlayes("Morning", "NightLoopSwitcher");
    }
}
