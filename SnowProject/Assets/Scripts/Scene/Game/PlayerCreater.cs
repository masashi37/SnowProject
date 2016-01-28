using UnityEngine;
using System.Collections;

public class PlayerCreater : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab = null;

    //-------------------------------------------

    void Start()
    {
        //CreatePlayer();
    }

    void CreatePlayer()
    {
        var obj = Instantiate(playerPrefab);

        obj.transform.parent = transform;

        obj.transform.localPosition =
            new Vector3(0, 5, 0);
    }
}