using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class CardSelect : MonoBehaviour
{
    public int[] cardNo;
    public PlayerControl player;

    private int curCard;
    private XmlNodeList nodeList;
    // Start is called before the first frame update
    void Start()
    {
        curCard = 0;
        TextAsset xmlFile = Resources.Load<TextAsset>("Data");
        XmlDocument document = new XmlDocument();
        document.LoadXml(xmlFile.text);

        nodeList = document.SelectSingleNode("Card").ChildNodes;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Act()
    {
        if (cardNo[curCard] < 0 || cardNo[curCard] > nodeList.Count)
        {
            player.Act(0, 0, 0);
        }
        player.Act(int.Parse(nodeList[cardNo[curCard]].ChildNodes[0].InnerText), int.Parse(nodeList[cardNo[curCard]].ChildNodes[1].InnerText), int.Parse(nodeList[cardNo[curCard]].ChildNodes[2].InnerText));
        curCard++;
        if(curCard>=cardNo.Length)
        {
            curCard = 0;
        }
    }
}
