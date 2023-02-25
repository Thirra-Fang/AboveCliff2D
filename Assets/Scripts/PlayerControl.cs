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
    public BattleControl battle;

    int curPos;
    int moveDir;
    static Vector3 UPD = new Vector3(0,1.6f,0);
    bool isInRightPlace;
    int waitingRepelDistance;
    bool repelStatus;//falseÎ´»÷ÍË£¬true¸Õ¿ªÊ¼»÷ÍË

    public bool getIsRightPlace()
    {
        return isInRightPlace;
    }
    public int getCurPos()
    {
        return curPos;
    }
    // Start is called before the first frame update
    void Start()
    {
        PlaceInit();
        MoveInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, plats.getPlat(curPos).transform.position+UPD, Time.deltaTime * moveSpeed);
        if (enemy.getIsRightPlace() && waitingRepelDistance != 0)
        {
            repelStatus = true;
            battle.setCanMove(false);
            curPos += waitingRepelDistance;
            waitingRepelDistance = 0;
        }
        isInRightPlace = Vector3.Distance(transform.position, plats.getPlat(curPos).transform.position + UPD) < 0.1f;
        if (enemy.getIsRightPlace()&&repelStatus && isInRightPlace)
        {
            repelStatus = false;
            battle.setPlayerRepeled(true);
            battle.setCanMove(true);
        }
        if ((transform.position.x < plats.getPlat(-plats.getBoundaryNum()).transform.position.x) || (transform.position.x > plats.getPlat(plats.getBoundaryNum()).transform.position.x))
        {
            battle.win(false);
        }
    }
    private void LateUpdate()
    {
    }

    public void Move(int x)
    {
        curPos += x;
    }
    public void Repeled(int y)
    {
        if (y == 0)
        {
            repelStatus = true;
        }
        else
        {
            waitingRepelDistance = y;
        }
    }
    
    void PlaceInit()
    {
        transform.position = plats.getPlat(initPos).transform.position+UPD;
        curPos = initPos;
        isInRightPlace = true;
        waitingRepelDistance = 0;
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
        repelStatus = false;
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
            StartCoroutine(waitForRepeled(y));
        }
        else
        {
            StartCoroutine(waitForRepeled(0));
        }
    }
    IEnumerator waitForRepeled(int y)
    {
        yield return new WaitForFixedUpdate();
        enemy.Repeled(y * moveDir);
    }
}
