using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCreateBlock : MonoBehaviour
{
    public GameConfig config;
    public Rigidbody player;

    private int prbCount = 50;  //创建50个后主角不死视为胜利
    private int currentCount = 0;
    private int currentCreatCount = 0;
    private float playerdis = 2.8f;
    private float playerz = 0;
    private float x = 0.6f;
    private float y = 1.2f;
    private float pz = -30f;

    public void ReSet()
    {
        //重置
    }

    void initLeftPrefab(float px)
    {
        currentCount += 1;
        currentCreatCount += 1;
        x -= 1 + px;
        float z = pz + (float)(3.3 * currentCount);
        Instantiate((GameObject)Resources.Load("Prefabs/block_type1"), new Vector3(x, y, z), Quaternion.identity);
    }

    void initRightPrefab(float px)
    {
        currentCount += 1;
        currentCreatCount += 1;
        x += 1 + px;
        float z = pz + (float)(3.3 * currentCount);

        Instantiate((GameObject)Resources.Load("Prefabs/block_type1"), new Vector3(x, y, z), Quaternion.identity);
    }

    void initJumpPrefab()
    {
        currentCount += 1;
        currentCreatCount += 1;
        x += 1;
        float z = pz + (float)(3.3 * currentCount);

        Instantiate((GameObject)Resources.Load("Prefabs/block_type2"), new Vector3(x, y, z), Quaternion.identity);
    }

    void HandlePrefab()
    {
        if (currentCreatCount <= 10)
        {
            initRightPrefab(0);
        }
        if (currentCreatCount > 10 && currentCreatCount <= 20)
        {
            initLeftPrefab(0);
        }

        if (currentCreatCount > 20 && currentCreatCount < 30)
        {
            if (IsOdd(currentCreatCount))
            {
                initRightPrefab(0);
            }
            else
            {
                initLeftPrefab(0);
            }
        }

        if (currentCreatCount == 30)
        {
            initJumpPrefab();
        }

        if (currentCreatCount == 31)
        {
            y += 2;
            pz += 7;
            initLeftPrefab(0);
        }

        if (currentCreatCount > 31)
        {
            currentCreatCount = 0;
            initJumpPrefab();
        }
    }

    public bool IsOdd(int n)
    {
        return (n % 2 == 1) ? true : false;
    }

    void Start()
    {
        playerz = player.transform.position.z;
    }

    void Update()
    {
        if (config.Start)
        {

            config.Process = currentCount;
            if (currentCount <= prbCount && player.transform.position.z - playerz > playerdis && player.transform.position.z - playerz < playerdis + 5)
            {
                playerz = player.transform.position.z;
                HandlePrefab();
            }
        }
    }
}
