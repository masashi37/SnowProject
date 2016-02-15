using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    Material type = null;

    int life = 0;

    //-------------------------------------------------------------

    void Start()
    {
        type = GetComponent<Renderer>().material;
        life = (type.name == "NormalEnemy (Instance)") ? 1 : 3;
    }

    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
            var point = (type.name == "NormalEnemy (Instance)") ? 1 : 5;
            Score.AddPoint(point);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "SnowBall(Clone)")
        {
            if (life > 0) life--;
        }
    }
}
