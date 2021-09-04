using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Night : MonoBehaviour
{
    private float SeconsLeft;
    private bool takingAway;

    void Start()
    {
        SeconsLeft = 3;
        takingAway = false;
    }
    void Update()
    {
        if (!takingAway && SeconsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }
    IEnumerator TimerTake()
    {
        takingAway = true;
        SeconsLeft -= 1;
        yield return new WaitForSeconds(1);
        if (SeconsLeft <= 0)
        {
            SceneManager.LoadScene("NightLoopSwitcher");
        }
        takingAway = false;
    }
}
