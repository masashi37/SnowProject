using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ModeText : MonoBehaviour
{
    public enum ModeType
    {
        NONE,
        SINGLE,
        SURVIVAL,
        TEAM_MATCH,
        MAX,
    }
    ModeType modeType;
    int modeChanger;

    Text text;

    //---------------------------------------

    void Start()
    {
        text = GetComponent<Text>();
        modeChanger = (int)ModeType.SINGLE;
    }

    void Update()
    {
        if (TextManager.Row == 0)
            ModeChanger();

        text.text = "Game Mode   :   " +
            modeType.ToString() + "   Mode";
    }

    //----------------------------------------

    public ModeType GetMode()
    {
        return modeType;
    }

    /// <summary>
    /// モード切替関数
    /// </summary>
    void ModeChanger()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            modeChanger -= (modeChanger - 1 > (int)ModeType.NONE) ? 1 : 0;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            modeChanger += (modeChanger + 1 < (int)ModeType.MAX) ? 1 : 0;

        modeType = (ModeType)modeChanger;
    }
}
