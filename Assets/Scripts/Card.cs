using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Text[] texts;

    int handNum = 0;
    string cardName = "Sample";
    int rush = 2;
    int smash = 1;
    int distance = 0;
    int limit = 1;
    PlayerControl player;
    HandCotrol hand;

    public void Generallize(int n,int l)
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

        handNum = l;
        cardName = elementCard.GetAttribute("name");
        rush = int.Parse(elementCard.ChildNodes[0].InnerText);
        smash = int.Parse(elementCard.ChildNodes[1].InnerText);
        distance = int.Parse(elementCard.ChildNodes[2].InnerText);
        limit = int.Parse(elementCard.ChildNodes[4].InnerText);

        texts[0].text = cardName;
        texts[2].text = rush.ToString();
        texts[3].text = smash.ToString();
        texts[4].text = distance.ToString();

    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform.GetComponent<PlayerControl>();
        hand = GameObject.FindWithTag("HandControl").transform.GetComponent<HandCotrol>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Discard()
    {
        player.Act(rush, smash, distance);
        hand.Discard(handNum);
        Destroy(gameObject);
    }
}
