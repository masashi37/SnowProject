using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    float time = 0.0f;

    Text result = null;

    //----------------------------------------------------

    void Start()
    {
        result = GetComponent<Text>();
    }

    void Update()
    {
        if (TimeLimit.time > 0) { result.text = ""; }
        else
        {
            result.text = string.Format(
                "TimeOver" + "\n\n\n\n\n" +
                "Score : {0}", Score.point);

            time += Time.deltaTime;
            if (time >= 10.0f) SceneManager.LoadScene("Title");
        }
    }
}
