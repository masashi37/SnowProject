using UnityEngine;
using System.Collections;
using System.IO;

public class SettingLoad : MonoBehaviour
{
    void Update()
    {
        StreamReader sr = new StreamReader(
            "Assets/Resource/Setting/setting.txt", false);

        var mode = sr.ReadLine();
        var number = sr.ReadLine();
        var time = sr.ReadLine();

        Debug.Log(mode);
        Debug.Log(number);
        Debug.Log(time);
    }
}
