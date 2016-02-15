using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameStartText : MonoBehaviour
{

    Text text;

    Color defaultColor;

    public static bool
        isReadySettingSave
    { get; private set; }

    //---------------------------------------

    void Start()
    {
        text = GetComponent<Text>();
        defaultColor = text.color;
        isReadySettingSave = false;
    }
    void Update()
    {
        if (TextManager.Row == 3)
        {
            text.color = Color.red;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                isReadySettingSave = true;
            }
        }
        else { text.color = defaultColor; }
    }
}
