using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleControl : MonoBehaviour
{
    public EnemyAI enemyAI;
    public bool isPlayerFirst;
    public HandCotrol hand;

    bool isPlayerRound;
    bool isEnemyRound;
    bool canMove;
    bool isEnemyWaiting;
    bool isPlayerWaiting;
    bool isPlayerRepeled;

    public void setPlayerRepeled(bool b)
    {
        isPlayerRepeled = b;
    }
    public bool getPlayerRound()
    {
        return isPlayerRound;
    }
    public bool getEnemyRound()
    {
        return isEnemyRound;
    }
    public bool getCanMove()
    {
        return canMove;
    }
    public void setPlayerRound(bool b)
    {
        isPlayerRound = b;
    }
    public void setEnemyRound(bool b)
    {
        isEnemyRound = b;
    }
    public void setCanMove(bool b)
    {
        canMove = b;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (isPlayerFirst)
        {
            canMove = true;
            isPlayerRound = true;
            isEnemyRound = false;
            isEnemyWaiting = false;
            isPlayerWaiting = false;
            isPlayerRepeled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemyWaiting && isEnemyRound)
        {
            isEnemyWaiting = false;
            enemyAI.Act();
        }
        if(isPlayerWaiting && isPlayerRepeled)
        {
            isPlayerWaiting = false;
            isPlayerRound = true;
            hand.Draw();
        }
        
    }
    public void playerRoundEnd()
    {
        isPlayerRound = false;
        isEnemyWaiting = true;
    }
    public void enemyRoundEnd()
    {
        isEnemyRound = false;
        isPlayerWaiting = true;
    }
}
