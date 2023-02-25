using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public EnemyControl enemy;
    public int[] enemyDeck;
    public BattleControl battle;

    EnemyAct[] enemyActs;
    int curCard;
    // Start is called before the first frame update
    void Start()
    {
        enemyDeckInitialization();
        curCard = 0;
    }
    // Update is called once per frame
    void Update()
    {
    }
    void enemyDeckInitialization()
    {
        enemyActs = new EnemyAct[12];
        for(int i = 0; i < 12; i++)
        {
            enemyActs[i] = new EnemyAct();
            enemyActs[i].Initialization(enemyDeck[i]);
        }
    }
    public void Act()
    {
        //以下批注项为随机出牌
        //int rd = (int)Random.Range(0.0f, 11.9999999f);
        //enemy.Act(enemyActs[rd].getRush(), enemyActs[rd].getSmash(), enemyActs[rd].getDistance());
        enemy.Act(enemyActs[curCard].getRush(), enemyActs[curCard].getSmash(), enemyActs[curCard].getDistance());
        if (enemyActs[curCard].getLimit()==1)
        {
            battle.enemyRoundEnd();
        }
        if (curCard < 11)
        {
            curCard++;
        }
        else
        {
            curCard = 0;
        }
    }
}
