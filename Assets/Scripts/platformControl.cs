using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformControl : MonoBehaviour
{
    public int startPlatformNum;

    private GameObject[] platform;
    // Start is called before the first frame update
    void Start()
    {
        platform = new GameObject[13];
        for(int i = 0; i < 13; i++)
        {
            platform[i] = transform.GetChild(i).gameObject;
        }
        for(int i = startPlatformNum; i < 13; i++)
        {
            platform[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
