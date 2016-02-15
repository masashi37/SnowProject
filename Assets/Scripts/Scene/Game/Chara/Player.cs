using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    enum TargetType
    {
        STAND,
        FRONT,
        BACK,
        MAX
    }
    TargetType targetType = TargetType.STAND;
    Vector3[] targetOffset = null;

    float angle;
    float move;

    int time = 0;

    bool canThrow = true;

    [SerializeField]
    GameObject snowBall = null;

    [SerializeField]
    GameObject ballArrival = null;

    [SerializeField]
    GameObject target = null;

    //---------------------------------------------

    void Start()
    {
        var planet = GameObject.Find("Planet");
        transform.localPosition = new Vector3(
            0,
            (planet.transform.localScale.y / 2) +
                (transform.localScale.y / 2),
            0);

        targetOffset = new Vector3[(int)TargetType.MAX] {
            new Vector3(0, 0, 3.2f),            //STAND
            new Vector3(0, 0, 3.0f),            //FRONT
            new Vector3(0, 0, 3.5f)};            //BACK
    }

    void Update()
    {
        Rotation();

        Move();

        SnowShot();
        ShotInterval();
    }

    void OnParticleCollision(GameObject other)
    {
        //Destroy(other);
    }

    //---------------------------------------------

    /// <summary>
    /// 移動の処理
    /// ※前後移動のみ
    /// </summary>
    void Move()
    {
        var moveSpeed = 0.05f;
        if (Input.GetKey(KeyCode.DownArrow))
            move = -moveSpeed;
        else if (Input.GetKey(KeyCode.UpArrow))
            move = moveSpeed;
        else { move = 0.0f; }

        ShotSaveing();

        transform.Translate(0, 0, move);
    }

    /// <summary>
    /// 移動中の弾の挙動調整
    /// ※生成位置とターゲット位置調整
    /// </summary>
    void ShotSaveing()
    {
        //前後
        if (Input.GetKey(KeyCode.UpArrow)) targetType = TargetType.FRONT;
        else if (Input.GetKey(KeyCode.DownArrow)) targetType = TargetType.BACK;

        if (!Input.GetKey(KeyCode.UpArrow) &&
            !Input.GetKey(KeyCode.DownArrow))
            targetType = TargetType.STAND;

        //左右

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            target.transform.localPosition += new Vector3(-0.5f, 0, 0);
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
            target.transform.localPosition += new Vector3(0.5f, 0, 0);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            target.transform.localPosition += new Vector3(0.5f, 0, 0);
        else if (Input.GetKeyUp(KeyCode.RightArrow))
            target.transform.localPosition += new Vector3(-0.5f, 0, 0);

        target.transform.localPosition =
            targetOffset[(int)targetType];
    }

    /// <summary>
    /// 向き変更の処理
    /// </summary>
    void Rotation()
    {
        var rotateSpeed = 2.0f;
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
            if (canThrow)
            {
                CreateSnowBall();
                canThrow = false;
            }
        }
    }

    /// <summary>
    /// 弾の発射時間制限
    /// </summary>
    void ShotInterval()
    {
        if (!canThrow)
        {
            time++;
            if (time > 60)
            {
                canThrow = true;
                time = 0;
            }
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
