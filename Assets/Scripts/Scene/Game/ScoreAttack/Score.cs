using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int point = 0;

    Text score = null;

    //----------------------------------------------------

    void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        if (TimeLimit.time > 0)
        {
            score.text =
            string.Format("Score" + "\n" + "{0}", point);
        }
        else { score.text = ""; }
    }

    public static void AddPoint(int addPoint)
    {
        point += addPoint;
    }
}
