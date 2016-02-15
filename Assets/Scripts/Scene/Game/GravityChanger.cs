using UnityEngine;
using System.Collections;

public class GravityChanger : MonoBehaviour
{
    GameObject planet = null;       // 引力の発生する星
    float coefficient = 6.674f;     // 万有引力係数

    //-------------------------------------------

    void Start()
    {
        planet = GameObject.Find("Planet");
    }

    void FixedUpdate()
    {
        var rigid = GetComponent<Rigidbody>();

        // 星に向かう向きの取得
        var direction =
            planet.transform.position -
            gameObject.transform.position;

        // 星までの距離の２乗を取得
        var distance = Vector3.Distance(
            planet.transform.position,
            gameObject.transform.position);
        distance *= distance;

        // 万有引力計算
        var gravity =
            coefficient *
            planet.GetComponent<Rigidbody>().mass *
            rigid.mass / distance;

        // 力を与える
        rigid.AddForce(
            gravity * direction,
            ForceMode.Force);
    }
}
