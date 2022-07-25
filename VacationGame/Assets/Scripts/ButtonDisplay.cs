using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDisplay : MonoBehaviour
{
    public GameObject button;

    public void HideButton()
    {
        button.SetActive(false);
    }
    public void ShowButton()
    {
        button.SetActive(true);
    }
}
