using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCotrol : MonoBehaviour
{
    public int[] deck;
    public GameObject cardProfab;
    public Transform[] pos;
    public int initDraw;

    int[] hand;
    int handNum;
    // Start is called before the first frame update
    void Start()
    {
        hand = new int[7];
        for(int i = 0; i < 7; i++)
        {
            hand[i] = -1;
        }
        handNum = 0;

        for(int i = 0; i < initDraw; i++)
        {
            Draw();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Draw()
    {
        if(handNum < 7)
        {
            int rd = (int)Random.Range(0.0f, 11.9999999f);
            Debug.Log(rd);
            hand[handNum] = deck[rd];
            Transform newCard = Instantiate(cardProfab, pos[handNum]).transform;
            newCard.GetComponent<Card>().Generallize(hand[handNum],handNum);
            newCard.localPosition = new Vector3(0, 0, 0);


            handNum ++;
        }
    }

    public void Discard(int l)
    {
        for (int i = l; i < handNum-1; i++)
        {
            Debug.Log(i.ToString()+"+"+handNum.ToString());
            hand[i] = hand[i + 1];
            Transform tempCard = pos[i + 1].GetChild(0);
            tempCard.position = pos[i].position;
            tempCard.GetComponent<Card>().ChangeHandNumBy(-1);
            tempCard.SetParent(pos[i]);
        }
        if (handNum < 7)
        {
            hand[handNum] = -1;
        }
        handNum--;
    }
}
