using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class CueController : MonoBehaviour
{
    public TextMeshProUGUI cue;
    public Color32 cueColour;

    public void ShowText(string msg)
    {
        cue.text = msg;
        cue.color = cueColour;
    }
}
