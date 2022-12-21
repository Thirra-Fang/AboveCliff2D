using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class Card : MonoBehaviour
{
    public void Generallize(int n)
    {
        TextAsset xmlFile = Resources.Load<TextAsset>("Data");
        XmlDocument document = new XmlDocument();
        document.LoadXml(xmlFile.text);

        XmlNodeList nodeList = document.SelectSingleNode("Card").ChildNodes;
        XmlElement elementCard = (XmlElement)nodeList[0];

        Debug.Log(elementCard.GetAttribute("name"));

        foreach (XmlElement element in elementCard.ChildNodes)
        {
            Debug.Log(element.InnerText);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
