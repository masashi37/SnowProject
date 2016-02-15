using UnityEngine;
using System.Collections;

public class PlayerCreater : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab = null;

    //-------------------------------------------

    void Start()
    {
        for (var i = 0; i < 0; ++i)
        {
            CreatePlayer(string.Format("Player{0}", i));
        }
    }

    void CreatePlayer(string playerName)
    {
        var obj = Instantiate(playerPrefab);
        obj.name = playerName;
        obj.transform.parent = transform;

        obj.transform.localPosition =
            new Vector3(0, 10, 0);
    }
}