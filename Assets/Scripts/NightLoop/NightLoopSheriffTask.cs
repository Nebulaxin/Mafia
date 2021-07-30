using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NightLoopSheriffTask : MonoBehaviour
{
    public GameObject CheckButtonPrefab;
    public static GameObject RoleTMP;
    public static GameObject NextButton;
    public static GameObject ListOfButtons;
    public static int i;

    private static GameObject KillButton;
    private GameObject InstantiatedGameObject;
    private float PositionOfPrefabY;
    private float PositionOfPrefabX;
    private float WidthOfPrefab;
    private float HeightOfPrefab;
    private float Margin;
    private string[] Roles = {""};

    public void Start()
    {
        KillButton = GameObject.Find("KillButton");
        NextButton = GameObject.FindGameObjectWithTag("NextButton");
        RoleTMP = GameObject.Find("RoleTMP");
        RoleTMP.SetActive(false);
        ListOfButtons = GameObject.Find("ListOfButtons");
        NextButton.SetActive(false);
        
        PositionOfPrefabY = KillButton.transform.position.y;
        PositionOfPrefabX = KillButton.transform.position.x;
        HeightOfPrefab = 150; //Screen.height / 12.8f;
        WidthOfPrefab = 1000;//Screen.width / 1.08f;
        Margin = Screen.height / 10.10526315789474f;//HeightOfPrefab + Screen.height / 48;
        Debug.Log("Margin " + Margin);

        for (i = 0; i < Menu.NumberOfPlayers; i++)
        {
            Check.NightSheriffTask();
            if (i < Menu.NumberOfPlayers)
            {
                PositionOfPrefabY -= Margin;
                InstantiatedGameObject = Instantiate(CheckButtonPrefab, new Vector3(PositionOfPrefabX, PositionOfPrefabY, 0), Quaternion.identity);
                InstantiatedGameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, WidthOfPrefab);
                InstantiatedGameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, HeightOfPrefab);
                InstantiatedGameObject.transform.SetParent(ListOfButtons.transform);
                InstantiatedGameObject.name = i.ToString();
                InstantiatedGameObject.GetComponentInChildren<TMP_Text>().text = Player.PlayersArray[i].nic.ToString();
                InstantiatedGameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                if (Player.PlayersArray[i].check == true && Player.PlayersArray[i].status == status.alive)
                {
                    Debug.Log(Player.PlayersArray[i].check + " Player.PlayersArray[i].check");
                    InstantiatedGameObject.GetComponent<Button>().interactable = false;
                    if (Player.PlayersArray[i].role == role.mafia)
                    {
                        InstantiatedGameObject.GetComponentInChildren<TMP_Text>().text = Player.PlayersArray[i].nic.ToString() + "(мафия)";
                    }
                    else
                    {
                        InstantiatedGameObject.GetComponentInChildren<TMP_Text>().text = Player.PlayersArray[i].nic.ToString() + "(не мафия)";
                    }
                }
            }
        }
    }
    public void Next()
    {
        Player.PlayersArray[ButtonInList.IndexSelectedPlayer].check = true;
        ArrayToConsole.Output("Next");
        Menu.column++;
        Check.AlivePlayes("Morning", "NightLoopSwitcher");
    }
}