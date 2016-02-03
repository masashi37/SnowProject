using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    public string nextScene;
    
    [SerializeField]
    public KeyCode whichKey;
    
    //-------------------------------
    
    void Update()
    {
        if (Input.GetKeyDown(whichKey))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
