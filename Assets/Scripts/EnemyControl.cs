using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public PlayerControl player;
    public int initPos;

    float unitsPerPlatform;
    int curPos;
    int moveDir;

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
    public void Move(int x)
    {
        curPos += x;
        transform.position = new Vector3(transform.position.x + unitsPerPlatform * x, transform.position.y, transform.position.z);
    }
    public void Repeled(int y)
    {
        curPos += y;
        transform.position = new Vector3(transform.position.x + unitsPerPlatform * y, transform.position.y, transform.position.z);

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
        transform.position = new Vector3(initPos * unitsPerPlatform, 0.0f, 0.0f);
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
        if (Mathf.Abs(player.getCurPos() - curPos) > z)
        {
            player.Repeled(y * moveDir);
        }
    }
}
