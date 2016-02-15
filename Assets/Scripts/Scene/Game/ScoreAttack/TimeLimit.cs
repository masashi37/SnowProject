using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    [SerializeField]
    public int second = 60;
    public static int time = 0;
    public static int waitTime = 60 * 3;

    Text timeLimit = null;

    //----------------------------------------------------

    void Start()
    {
        timeLimit = GetComponent<Text>();

        time = 60 * second;
    }

    void Update()
    {
        waitTime--;
        if (waitTime > 0) return;

        if (time > 0)
        {
            time--;

            timeLimit.text =
                string.Format("TimeLimit" + "\n" + "{0},s", (time / 60));
        }
        else { timeLimit.text = ""; }
    }
}
