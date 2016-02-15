using UnityEngine;
using System.Collections;
using System;

public class CreateTarget : MonoBehaviour
{
    float time = 0;
    const float createTime = 6.0f;
    
    const int MAX_COUNT = 5;

    const int RANDOM_POS = 8;

    bool[] isExist = new bool[MAX_COUNT]
    {
        false,false,false,false,false
    };

    string[] TARGET_NAME =
        new string[MAX_COUNT]
        {
            "Target(1)",
            "Target(2)",
            "Target(3)",
            "Target(4)",
            "Target(5)"
        };

    [SerializeField]
    public GameObject targetPrefab = null;

    [SerializeField]
    public Material normal = null;

    [SerializeField]
    public Material hard = null;

    //---------------------------------------

    void Update()
    {
        for (var i = 0; i < MAX_COUNT; ++i)
        {
            ExistScan(i);

            if (!isExist[i])
            {
                time += Time.deltaTime;

                if (time > createTime)
                {
                    TargetCreate(TARGET_NAME[i]);
                    isExist[i] = true;
                    time = 0;
                }
            }
        }
    }

    //---------------------------------------

    void ExistScan(int i)
    {
        if (GameObject.Find(TARGET_NAME[i]) == null) isExist[i] = false;
    }

    void TargetCreate(string name)
    {
        var random = new System.Random();
        var level = random.Next(0, 10);

        var target = Instantiate(targetPrefab);
        
        target.GetComponent<Renderer>().material =
            (level > 7) ? hard : normal;

        target.name = name;

        var size = ((float)random.NextDouble() / 2) + 0.5f;
        target.transform.localScale = new Vector3(
                size, size, size);

        target.transform.localPosition = new Vector3(
                random.Next(-RANDOM_POS, RANDOM_POS),
                random.Next(-RANDOM_POS, RANDOM_POS),
                random.Next(-RANDOM_POS, RANDOM_POS));
    }
}
