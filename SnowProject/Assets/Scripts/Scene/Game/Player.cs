using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    const float rotateSpeed = 2.0f;
    const float moveSpeed = 0.05f;

    float angle;
    float move;

    [SerializeField]
    GameObject snowBall = null;

    GameObject ballArrival = null;

    //---------------------------------------------

    void Start()
    {
        var planet = GameObject.Find("Planet");
        transform.localPosition = new Vector3(
            0,
            (planet.transform.localScale.y / 2) +
            (transform.localScale.y / 2),
            0);

        ballArrival =
            GameObject.Find("BallPos");
    }

    void Update()
    {
        Rotation();
        Move();
        SnowShot();
    }

    //---------------------------------------------

    /// <summary>
    /// 移動の処理
    /// ※前後移動のみ
    /// </summary>
    void Move()
    {
        if (Input.GetKey(KeyCode.DownArrow)) move = -moveSpeed;
        else if (Input.GetKey(KeyCode.UpArrow)) move = moveSpeed;
        else { move = 0.0f; }
        transform.Translate(0, 0, move);
    }

    /// <summary>
    /// 向き変更の処理
    /// </summary>
    void Rotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) angle = -rotateSpeed;
        else if (Input.GetKey(KeyCode.RightArrow)) angle = rotateSpeed;
        else { angle = 0.0f; }
        transform.Rotate(0, angle, 0);
    }

    /// <summary>
    /// 弾を投げる
    /// </summary>
    void SnowShot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateSnowBall();
        }
    }

    /// <summary>
    /// 弾を生成
    /// </summary>
    void CreateSnowBall()
    {
        var ball = Instantiate(snowBall);

        ball.transform.position =
            ballArrival.transform.position;
    }
}
