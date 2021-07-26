using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonInList : MonoBehaviour
{
    public static int IndexSelectedPlayer;
    public void OnClick()
    {
        Scene scene = SceneManager.GetActiveScene();
        IndexSelectedPlayer = Convert.ToInt32(name);
        Debug.Log("IndexSellectedPlayer " + IndexSelectedPlayer);
        switch (scene.name)
        {
            case "NightLoopMafiaTask":
                NightLoopMafiaTask.NextButton.SetActive(true);
                break;
            case "NightLoopDoctorTask":
                NightLoopDoctorTask.NextButton.SetActive(true);
                break;
        }
    }
}
