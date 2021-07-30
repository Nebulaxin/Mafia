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
    public void ShowRole()
    {
        IndexSelectedPlayer = Convert.ToInt32(name);
        NightLoopSheriffTask.NextButton.SetActive(true);
        NightLoopSheriffTask.RoleTMP.SetActive(true);
        NightLoopSheriffTask.ListOfButtons.SetActive(false);
        if (Player.PlayersArray[Convert.ToInt32(name)].role == role.mafia)
        {
            NightLoopSheriffTask.RoleTMP.GetComponentInChildren<TMP_Text>().text = Player.PlayersArray[Convert.ToInt32(name)].nic.ToString() + " мафия";
        }
        else
        {
            NightLoopSheriffTask.RoleTMP.GetComponentInChildren<TMP_Text>().text = Player.PlayersArray[Convert.ToInt32(name)].nic.ToString() + " не мафия";
        }
    }
}
