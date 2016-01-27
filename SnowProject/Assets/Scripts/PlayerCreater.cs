using UnityEngine;
using System.Collections;

public class PlayerCreater : MonoBehaviour
{
    int time = 0;

    [SerializeField]
    GameObject playerPrefab = null;

    //-------------------------------------------

    void Update()
    {
        time++;

        if (time % (60 * 2) == 0)
        {
            CreatePlayer();
        }
    }

    void CreatePlayer()
    {
        var obj = Instantiate(playerPrefab);

        obj.transform.localPosition =
            new Vector3(
                Random.Range(-5, 5),
                Random.Range(-5, 5),
                Random.Range(-5, 5));
    }
}