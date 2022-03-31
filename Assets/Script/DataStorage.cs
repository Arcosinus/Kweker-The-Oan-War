using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class DataStorage : MonoBehaviour
{
    public int savenum;
    public int sante;
    public int prog;
    public int inspe;
    public int level;
    public string W1;
    public string W2;
    public void HealAll()
    {
        sante = 16;
    }
    public int GetProg()
    {
        return prog;
    }
    public void SetProg(int num)
    {
        prog = num;
    }
    public void SetSav(int num)
    {
        savenum = num;
    }
    public void Save()
    {
        XmlWriter xmlWriter = XmlWriter.Create("Assets/Save/"+savenum+"save.xml");

        xmlWriter.WriteStartDocument();
        xmlWriter.WriteStartElement("Save");

        xmlWriter.WriteStartElement("Sante");
        xmlWriter.WriteAttributeString("int",sante+"");
        xmlWriter.WriteEndElement();

        xmlWriter.WriteStartElement("Progression");
        xmlWriter.WriteAttributeString("int",prog+"");
        xmlWriter.WriteEndElement();

        xmlWriter.WriteStartElement("Inspecteur");
        xmlWriter.WriteAttributeString("int",inspe+"");
        xmlWriter.WriteEndElement();

        xmlWriter.WriteStartElement("Level");
        xmlWriter.WriteAttributeString("int",level+"");
        xmlWriter.WriteEndElement();

        xmlWriter.WriteStartElement("Weapon1");
        xmlWriter.WriteAttributeString("int",W1+"");
        xmlWriter.WriteEndElement();

        xmlWriter.WriteStartElement("Weapon2");
        xmlWriter.WriteAttributeString("int",W2+"");
        xmlWriter.WriteEndElement();

        xmlWriter.WriteEndDocument();
        xmlWriter.Close();
    }
    public void LoadSave()
    {
        XmlReader xmlReader = XmlReader.Create("Assets/Save/"+savenum+"save.xml");
            while(xmlReader.Read())
            {
                if((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Sante"))
                {
                    sante = int.Parse(xmlReader.GetAttribute("int"));                    
                }
                if((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Progression"))
                {
                    prog = int.Parse(xmlReader.GetAttribute("int"));                    
                }
                if((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Inspecteur"))
                {
                    inspe = int.Parse(xmlReader.GetAttribute("int"));                    
                }
                if((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Level"))
                {
                    level = int.Parse(xmlReader.GetAttribute("int"));                    
                }
                if((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Weapon1"))
                {
                    W1 = xmlReader.GetAttribute("int");                    
                }
                if((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Weapon2"))
                {
                    W2 = xmlReader.GetAttribute("int");                    
                }
            }
    }
    public void GetData()
    {
        if(GameObject.Find("Arxcoz"))
        {
            sante = GameObject.Find("Arxcoz").GetComponent<Player>().GetSante();
            W1 = GameObject.Find("Arxcoz").GetComponent<Player>().GetW1();
            W2 = GameObject.Find("Arxcoz").GetComponent<Player>().GetW2();
        }
    }
    public void SetData()
    {
        if(GameObject.Find("Arxcoz"))
        {
            GameObject.Find("Arxcoz").GetComponent<Player>().SetSante(sante);
            GameObject.Find("Arxcoz").GetComponent<Player>().SetW1(W1);
            GameObject.Find("Arxcoz").GetComponent<Player>().SetW2(W2);
        }
        if(GameObject.Find("Carte"))
        {
            GameObject.Find("Carte").GetComponent<Progression>().SetProg(prog);
            GameObject.Find("Carte").GetComponent<Progression>().SetInspe(inspe);
            GameObject.Find("Carte").GetComponent<Progression>().SetLevel(level);
        }
    }
    public void SetLevel(int lvl)
    {
        level = lvl;
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad (transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
