using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Won : MonoBehaviour
{
    public TMP_Text WinsTeam;
    public static string Winner;

    private void Start()
    {
        WinsTeam.text = Winner;
    }
    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }
}
