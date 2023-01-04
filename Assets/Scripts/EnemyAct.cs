using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class EnemyAct
{
    string cardName = "Sample";
    int rush = 2;
    int smash = 1;
    int distance = 0;
    int limit = 1;

    public void Initialization(int n)
    {

        TextAsset xmlFile = Resources.Load<TextAsset>("Data");
        XmlDocument document = new XmlDocument();
        document.LoadXml(xmlFile.text);

        XmlNodeList nodeList = document.SelectSingleNode("Cards").ChildNodes;
        XmlElement elementCard = (XmlElement)nodeList[n];

        Debug.Log(elementCard.GetAttribute("name"));

        foreach (XmlElement element in elementCard.ChildNodes)
        {
            Debug.Log(element.InnerText);
        }

        cardName = elementCard.GetAttribute("name");
        rush = int.Parse(elementCard.ChildNodes[0].InnerText);
        smash = int.Parse(elementCard.ChildNodes[1].InnerText);
        distance = int.Parse(elementCard.ChildNodes[2].InnerText);
        limit = int.Parse(elementCard.ChildNodes[4].InnerText);
    }
    public int getRush()
    {
        return rush;
    }
    public int getSmash()
    {
        return smash;
    }
    public int getDistance()
    {
        return distance;
    }
    public int getLimit()
    {
        return limit;
    }
}
