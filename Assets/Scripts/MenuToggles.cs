using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuToggles : MonoBehaviour
{
    public void OnValueChanged()
    {
        GameObject ThisToggle = GameObject.Find(name);
        Menu.NumberOfCivilians = Convert.ToInt32(Menu.NumberOfPlayersInputTMP.GetComponent<TMP_InputField>().text) - Menu.NumberOfMafias;
        if (ThisToggle.GetComponent<Toggle>().isOn)
        {
            if (Menu.doctor.GetComponent<Toggle>().isOn)
            {
                --Menu.NumberOfCivilians;
            }
            if (Menu.sheriff.GetComponent<Toggle>().isOn)
            {
                --Menu.NumberOfCivilians;
            }
            if (Menu.NumberOfCivilians >= 2)
            {
                ThisToggle.GetComponent<Toggle>().isOn = true;
            }
            else
            {
                ThisToggle.GetComponent<Toggle>().isOn = false;
            }
        }
    }
}
