using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class SetXML : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Write();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Write()
    {
        TextAsset xmlFile = Resources.Load<TextAsset>("Data");
        XmlDocument myDoc = new XmlDocument();
        myDoc.LoadXml(xmlFile.text);

        XmlNode node = myDoc.DocumentElement;

        for(int i = 0; i <= 50; i++)
        {
            int collectionNewNo = node.ChildNodes.Count;
            XmlElement newElement = myDoc.CreateElement("Card" + collectionNewNo.ToString());
            newElement.SetAttribute("name", "Sample" + collectionNewNo.ToString());
            XmlElement newRush = myDoc.CreateElement("rush");
            XmlElement newSmash = myDoc.CreateElement("smash");
            XmlElement newDistance = myDoc.CreateElement("distance");
            XmlElement newEffect = myDoc.CreateElement("effect");
            XmlElement newLimit = myDoc.CreateElement("limit");

            node.AppendChild(newElement);
            newElement.AppendChild(newRush);
            newRush.InnerText = "2";
            newElement.AppendChild(newSmash);
            newSmash.InnerText = "1";
            newElement.AppendChild(newDistance);
            newDistance.InnerText = "0";
            newElement.AppendChild(newEffect);
            newEffect.InnerText = "None";
            newElement.AppendChild(newLimit);
            newLimit.InnerText = "1";

        }

        myDoc.Save(Application.dataPath+"/Resources/Data.xml");

        Debug.Log("completed");
    }

}
