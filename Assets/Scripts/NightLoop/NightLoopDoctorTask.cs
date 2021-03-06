using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NightLoopDoctorTask : MonoBehaviour
{
    public GameObject HealButtonPrefab;
    public static GameObject NextButton;
    public static int i;

    private static GameObject KillButton;
    private GameObject InstantiatedGameObject;
    private Transform Panel;
    private float PositionOfPrefabY;
    private float PositionOfPrefabX;
    private float WidthOfPrefab;
    private float HeightOfPrefab;
    private float Margin;

    public void Start()
    {
        KillButton = GameObject.Find("KillButton");
        NextButton = GameObject.FindGameObjectWithTag("NextButton");
        Panel = GameObject.Find("Panel").transform;
        NextButton.SetActive(false);
        
        PositionOfPrefabY = KillButton.transform.position.y;
        PositionOfPrefabX = KillButton.transform.position.x;
        HeightOfPrefab = 150; //Screen.height / 12.8f;
        WidthOfPrefab = 1000;//Screen.width / 1.08f;
        Margin = Screen.height / 10.10526315789474f;//HeightOfPrefab + Screen.height / 48;
        Debug.Log("Margin " + Margin);
        ArrayToConsole.Output("NightLoopDoctorTask");

        for (i = 0; i < Menu.NumberOfPlayers; i++)
        {
            Check.NightDoctorTask();
            if (i < Menu.NumberOfPlayers)
            {
                PositionOfPrefabY -= Margin;
                InstantiatedGameObject = Instantiate(HealButtonPrefab, new Vector3(PositionOfPrefabX, PositionOfPrefabY, 0), Quaternion.identity);
                InstantiatedGameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, WidthOfPrefab);
                InstantiatedGameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, HeightOfPrefab);
                InstantiatedGameObject.transform.SetParent(Panel);
                InstantiatedGameObject.name = i.ToString();
                InstantiatedGameObject.GetComponentInChildren<TMP_Text>().text = Player.PlayersArray[i].nic.ToString();
                InstantiatedGameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }
    }
    public void Next()
    {
        Player.PlayersArray[ButtonInList.IndexSelectedPlayer].health = health.heal;
        ArrayToConsole.Output("Next");
        Menu.column++;
        Check.AlivePlayes("Morning", "NightLoopSwitcher");
    }
}