using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Morning : MonoBehaviour
{
    private float SeconsLeft;
    private bool takingAway;

    private void Start()
    {
        SeconsLeft = 3;
        takingAway = false;
        for (int i = 0; i < Menu.NumberOfPlayers; i++)
        {
            if (Player.PlayersArray[i].status == status.die && Player.PlayersArray[i].health == health.heal)
            {
                Player.PlayersArray[i].status = status.alive;
            }
        }
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
            SceneManager.LoadScene("DiedPlayers");
        }
        takingAway = false;
    }
}
