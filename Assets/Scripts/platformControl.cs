using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    public int startPlatformNum;
    public GameObject[] platform;

    public int getBoundaryNum()
    {
        return (startPlatformNum - 1)/2;
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = startPlatformNum; i < 13; i++)
        {
            platform[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject getPlat(int i)
    {
        if (i <= 0)
        {
            return platform[-2*i];
        }
        else
        {
            return platform[2*i-1];
        }
    }
}
