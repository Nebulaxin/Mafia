using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NightLoopSwitcher : MonoBehaviour
{
    public TMP_Text AreYouThisPlayer;

    void Start()
    {
        Check.AliveColumn();
        Debug.Log("Menu.column " + Menu.column);
        AreYouThisPlayer.text = "Pass your phone to Player " + Player.PlayersArray[Menu.column].nic;
        DiedPlayers.NextScene = "DayLoopTalk";
    }
    public void Next()
    {
        Check.Role();
    }
}
