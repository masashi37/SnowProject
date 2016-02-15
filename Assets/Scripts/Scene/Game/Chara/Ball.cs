using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    float time = 0;
    
    GameObject chara = null;
    GameObject targetObj = null;

    //-------------------------------------

    void Start()
    {
        chara = GameObject.Find("Player1");
        targetObj = chara.transform.FindChild("TargetPos").gameObject;
    }

    void FixedUpdate()
    {
        var rigid = GetComponent<Rigidbody>();
        var target = targetObj.transform.position;
        var vec = target - transform.position;

        time += Time.deltaTime;
        if (time < 0.2f)
            rigid.AddForce(vec, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
