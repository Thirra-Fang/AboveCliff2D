using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public EnemyControl enemy;
    public int[] enemyDeck;

    EnemyAct[] enemyActs;
    // Start is called before the first frame update
    void Start()
    {
        enemyDeckInitialization();
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
        int rd = (int)Random.Range(0.0f, 11.9999999f);
        enemy.Act(enemyActs[rd].getRush(), enemyActs[rd].getSmash(), enemyActs[rd].getDistance());
    }
}
