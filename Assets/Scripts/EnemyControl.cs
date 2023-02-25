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
    public BattleControl battle;

    float unitsPerPlatform;
    int curPos;
    int moveDir;
    static Vector3 UPD = new Vector3(0, 1.6f, 0);
    int waitingRepelDistance;
    bool isInRightPlace;
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
        if (player.getIsRightPlace()&&waitingRepelDistance!=0)
        {
            repelStatus = true;
            curPos += waitingRepelDistance;
            waitingRepelDistance = 0;
        }
        isInRightPlace = Vector3.Distance(transform.position, plats.getPlat(curPos).transform.position + UPD) < 0.1f;
        if (player.getIsRightPlace()&&repelStatus &&isInRightPlace)
        {
            repelStatus = false;
            battle.setEnemyRound(true);
            battle.setCanMove(true);
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
        if(y == 0)
        {
            repelStatus = true;
        }
        else
        {
            waitingRepelDistance = y;
        }
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
        repelStatus = false;
    }
    void PlaceInit()
    {
        transform.position = plats.getPlat(initPos).transform.position + UPD;
        curPos = initPos;
        isInRightPlace = true;
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
            StartCoroutine(waitForRepeled(y));
        }
        else
        {
            StartCoroutine(waitForRepeled(0));
        }
    }
    public void Test()
    {
        Debug.Log("111");
    }
    IEnumerator waitForRepeled(int y)
    {
        yield return new WaitForFixedUpdate();
        player.Repeled(y * moveDir);
    }
}
