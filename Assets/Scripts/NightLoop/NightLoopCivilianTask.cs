using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NightLoopCivilianTask : MonoBehaviour
{
    public GameObject RedButton;
    public GameObject NextButton;

    private void Start()
    {
        NextButton.SetActive(false);
        RedButton.SetActive(true);
    }
    public void Red()
    {
        NextButton.SetActive(true);
        RedButton.SetActive(false);
    }
    public void Next()
    {
        ++Menu.column;
        Check.AlivePlayes("Morning", "NightLoopSwitcher");
    }

}
