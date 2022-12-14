using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int initPos;
    public float unitsPerPlatform;
    public EnemyControl enemy;

    int curPos;
    int moveDir;

    public int getCurPos()
    {
        return curPos;
    }
    // Start is called before the first frame update
    void Start()
    {
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
    
    void PlaceInit()
    {
        transform.position=new Vector3(initPos * unitsPerPlatform, 0.0f, 0.0f);
        curPos = initPos;
    }
    void MoveInit()
    {
        if (enemy.getCurPos() - curPos >= 0)
        {
            moveDir = 1;
        }
        else
        {
            moveDir = -1;
        }
    }

    public void Act(int x,int y,int z)
    {
        if (enemy.getCurPos() - curPos < 0)
        {
            moveDir = -1;
        }
        else if(enemy.getCurPos() - curPos > 0)
        {
            moveDir = 1;
        }


        if (Mathf.Abs(enemy.getCurPos()-curPos)>x)
        {
            Move(x*moveDir);
        }
        else
        {
            Move(enemy.getCurPos() - curPos);
        }
        if (Mathf.Abs(enemy.getCurPos()-curPos)<=z)
        {
            enemy.Repeled(y*moveDir);
        }
    }
}
