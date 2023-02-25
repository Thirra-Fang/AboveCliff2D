using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public PlayerControl player;
    public int initPos;
    public PlatformControl plats;
    public float moveSpeed;
    public float repelSpeed;

    float unitsPerPlatform;
    int curPos;
    int moveDir;
    static Vector3 UPD = new Vector3(0, 1.6f, 0);

    public int getCurPos()
    {
        return curPos;
    }
    // Start is called before the first frame update
    void Start()
    {
        MoveInit();
        PlaceInit();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, plats.getPlat(curPos).transform.position+UPD, Time.deltaTime * moveSpeed);
    }

    public void Move(int x)
    {
        curPos += x;
    }
    public void Repeled(int y)
    {
        curPos += y;
    }
    void MoveInit()
    {
        unitsPerPlatform = player.unitsPerPlatform;
        if (player.getCurPos() - curPos <= 0)
        {
            moveDir = -1;
        }
        else
        {
            moveDir = 1;
        }
    }
    void PlaceInit()
    {
        transform.position = plats.getPlat(initPos).transform.position + UPD;
        curPos = initPos;
    }

    public void Act(int x, int y, int z)
    {
        if (player.getCurPos() - curPos < 0)
        {
            moveDir = -1;
        }
        else if (player.getCurPos() - curPos > 0)
        {
            moveDir = 1;
        }


        if (Mathf.Abs(player.getCurPos() - curPos) > x)
        {
            Move(x * moveDir);
        }
        else
        {
            Move(player.getCurPos() - curPos);
        }
        if (Mathf.Abs(player.getCurPos() - curPos) <= z)
        {
            player.Repeled(y * moveDir);
        }
    }
    public void Test()
    {
        Debug.Log("111");
    }
}
