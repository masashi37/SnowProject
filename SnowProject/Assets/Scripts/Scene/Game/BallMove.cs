using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour
{
    float time = 0;

    void FixedUpdate()
    {
        var rigid = GetComponent<Rigidbody>();
        GameObject parents = gameObject.transform.parent.gameObject;
        var target = parents.transform.position + (Vector3.forward * 3);
        var vec = target - transform.position;

        time += Time.deltaTime;
        if (time < 0.5f)
            rigid.AddForce(vec, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name !=
            gameObject.transform.parent.gameObject.name)
            Destroy(gameObject);
    }
}
