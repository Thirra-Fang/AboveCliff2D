using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int initPos;
    public float unitsPerPlatform;
    public EnemyControl enemy;
    public PlatformControl plats;
    public float moveSpeed;
    public float repelSpeed;

    int curPos;
    int moveDir;
    static Vector3 UPD = new Vector3(0,1.6f,0);

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
    
    void PlaceInit()
    {
        transform.position = plats.getPlat(initPos).transform.position+UPD;
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
