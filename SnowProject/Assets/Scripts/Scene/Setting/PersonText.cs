using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PersonText : MonoBehaviour
{
    int numberChanger;

    const int NUMBER_MIN = 1;
    const int NUMBER_MAX = 4;

    Text text;

    //---------------------------------------

    void Start()
    {
        text = GetComponent<Text>();
        numberChanger = NUMBER_MIN;
    }

    void Update()
    {
        if (TextManager.Row == 1)
            NumberChanger();

        text.text = "Number of Person   :   " +
            numberChanger + "   Number";
    }

    //----------------------------------------

    public int GetNumber()
    {
        return numberChanger;
    }

    /// <summary>
    /// 人数切替関数
    /// </summary>
    void NumberChanger()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            numberChanger -= (
                numberChanger > NUMBER_MIN) ? 1 : 0;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            numberChanger += (
                numberChanger < NUMBER_MAX) ? 1 : 0;
    }
}
