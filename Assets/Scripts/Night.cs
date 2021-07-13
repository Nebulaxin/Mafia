using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Night : MonoBehaviour
{
    private float SeconsLeft = 3;

    void Start()
    {
        RepeatVote.RepeartVote = false;
    }
    void Update()
    {
        if (SeconsLeft > 0)
        {
            SeconsLeft -= Time.deltaTime;
        }
        if (SeconsLeft <= 0)
        {
            SceneManager.LoadScene("NightLoopSwitcher");
        }
    }
}
