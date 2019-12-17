using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CuePresenter : MonoBehaviour
{
    public TextMeshProUGUI lable;
    public Color32 lableColor;

    public void ShowText(string msg)
    {
        lable.text = msg;
        lable.color = lableColor;
    }
}
