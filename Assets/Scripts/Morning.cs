using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Morning : MonoBehaviour
{
    private float SeconsLeft = 3;

    private void Start()
    {
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
        if (SeconsLeft > 0)
        {
            SeconsLeft -= Time.deltaTime;
        }
        if (SeconsLeft <= 0)
        {
            SceneManager.LoadScene("DiedPlayers");
        }
    }
}
