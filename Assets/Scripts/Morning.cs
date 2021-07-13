using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Morning : MonoBehaviour
{
    private float SeconsLeft = 3;

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
