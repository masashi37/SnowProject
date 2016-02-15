using UnityEngine;
using System.Collections;

public class TextManager : MonoBehaviour
{

    public static int Row { get; private set; }

    public const int ROW_MIN = 0;
    public const int ROW_MAX = 3;

    //---------------------------------------------

    void Start()
    {
        Row = 0;
    }

    void Update()
    {
        LineNumberMove();
    }

    //---------------------------------------------

    /// <summary>
    /// 行変更
    /// </summary>
    public static void LineNumberMove()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Row -= (Row > ROW_MIN) ? 1 : 0;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            Row += (Row < ROW_MAX) ? 1 : 0;
    }
}
