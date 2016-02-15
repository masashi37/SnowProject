using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;

public class SettingSave : MonoBehaviour
{
    [SerializeField]
    public ModeText mode;

    [SerializeField]
    public PersonText person;

    [SerializeField]
    public TimeText time;

    [SerializeField]
    public string nextScene;

    //--------------------------------------------

    void Update()
    {
        if (!GameStartText.isReadySettingSave) return;

        StreamWriter sw = new StreamWriter(
            "Assets/Resource/Setting/setting.txt", false);

        sw.WriteLine(mode.GetMode().ToString());
        sw.WriteLine(person.GetNumber().ToString());
        sw.WriteLine(time.GetTime().ToString());

        sw.Flush();
        sw.Close();

        SceneManager.LoadScene(nextScene);
    }
}
