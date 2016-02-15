using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    int timeChanger;

    const int TIME_MIN = 1;
    const int TIME_MAX = 3;

    Text text;

    //---------------------------------------

    void Start()
    {
        text = GetComponent<Text>();
        timeChanger = TIME_MIN;
    }

    void Update()
    {
        if (TextManager.Row == 2)
            TimeChanger();

        text.text = "Time   :   " +
            timeChanger + "   Minutes";
    }

    //----------------------------------------

    public int GetTime()
    {
        return timeChanger;
    }

    /// <summary>
    /// 時間切替関数
    /// </summary>
    void TimeChanger()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            timeChanger -= (
                timeChanger > TIME_MIN) ? 1 : 0;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            timeChanger += (
                timeChanger < TIME_MAX) ? 1 : 0;
    }
}
