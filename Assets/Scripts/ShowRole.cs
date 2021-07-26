using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShowRole : MonoBehaviour
{
    public TMP_Text YourRoleTMP;
    public TMP_Text ButtonTextTMP;
    private string[] YourRoleTexts = {"мирный житель", "мафия", "доктор", "шериф"};

    public void Start()
    {
        YourRoleTMP.text = "Вы " + YourRoleTexts[(int)Player.PlayersArray[Menu.column].role];
        /*if (Player.PlayersArray[Menu.column].role == role.civilian)
        {
            YourRoleTMP.text = "Вы мирный житель";
        }
        else
        {
            YourRoleTMP.text = "Вы мафия";
        }*/
    }
    public void NextPlayer()
    {
        ++Menu.column;
        if (Menu.column != Menu.NumberOfPlayers)
        {
            ArrayToConsole.Output("Next()");
            SceneManager.LoadScene("InputPlayersName");
        }
        else
        {
            Menu.column = 0;
            InputPlayersName.NumberOfPlayer = 0;
            ArrayToConsole.Output("Next() all names inputed");
            SceneManager.LoadScene("StartGame");
        }
    }
}
