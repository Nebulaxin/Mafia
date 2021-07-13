using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NightLoopMafiaTask : MonoBehaviour
{
    public void Kill()
    {
        //GameObject PressedButton = GameObject.Find(name);
        NightLoopMafiaTaskMenu.IndexKilledPlayer = Convert.ToInt32(name);
        Debug.Log("NightLoopMafiaTaskMenu.IndexKilledPlayer " + NightLoopMafiaTaskMenu.IndexKilledPlayer);
        Debug.Log(NightLoopMafiaTaskMenu.NextButton);
        NightLoopMafiaTaskMenu.NextButton.SetActive(true);
    }
}
