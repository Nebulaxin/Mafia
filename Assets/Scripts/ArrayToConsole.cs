using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class ArrayToConsole : MonoBehaviour
{
    public static void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
    public static void Output(string VoidAndLine)
    {
        ClearLog();
        Debug.Log("Output from " + VoidAndLine);
        for (int i = 0; i < Menu.NumberOfPlayers; i++)
        {
            Debug.Log(Player.PlayersArray[i].nic + "   " + Player.PlayersArray[i].role + "   " + Player.PlayersArray[i].status + "   " + Player.PlayersArray[i].health + "   " + Player.PlayersArray[i].votes);
        }
        Debug.Log(Menu.column);
    }
}