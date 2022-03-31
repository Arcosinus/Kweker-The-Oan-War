using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    int choix = 1;
    int savechoix = 1;
    bool zoom = false;
    float zoomlevel = 14;
    bool command = false;
    public GameObject lancement;
    public AudioSource menu;
    public GameObject explication;
    public GameObject save;
    public GameObject data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(choix == 1 && !(save.transform.position.z == -4))
        {
            transform.position = new Vector3(transform.position.x,110.6f,transform.position.z);
        }
        if(choix == 2 && !(save.transform.position.z == -4))
        {
            transform.position = new Vector3(transform.position.x,107.7f,transform.position.z);
        }
        if(choix == 3 && !(save.transform.position.z == -4))
        {
            transform.position = new Vector3(transform.position.x,104.6f,transform.position.z);
        }
        if(choix == 4 && !(save.transform.position.z == -4))
        {
            transform.position = new Vector3(transform.position.x,101.6f,transform.position.z);
        }
        if(!(save.transform.position.z == -4) && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && choix < 4)
        {
            choix++;
        }
        if(!(save.transform.position.z == -4) && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && choix > 1)
        {
            choix--;
        }
        if((save.transform.position.z == -4) && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && savechoix < 3)
        {
            savechoix++;
        }
        if((save.transform.position.z == -4) && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && savechoix > 1)
        {
            savechoix--;
        }
        if(Input.GetKeyDown(KeyCode.Space)&& choix == 1)
        {
            save.transform.position = new Vector3(save.transform.position.x,save.transform.position.y,-4);
            transform.position = new Vector3(-4,111.5f,transform.position.z);
        }
        if(savechoix == 1 && (save.transform.position.z == -4))
        {
            transform.position = new Vector3(transform.position.x,111.5f,transform.position.z);
        }
        if(savechoix == 2 && (save.transform.position.z == -4))
        {
            transform.position = new Vector3(transform.position.x,109.5f,transform.position.z);
        }
        if(savechoix == 3 && (save.transform.position.z == -4))
        {
            transform.position = new Vector3(transform.position.x,107,transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.Escape)&&(save.transform.position.z == -4))
        {
            save.transform.position = new Vector3(save.transform.position.x,save.transform.position.y,-6);
            transform.position = new Vector3(-14.11f,transform.position.y,transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.E)&& savechoix == 1 && choix == 1)
        {
            data.GetComponent<DataStorage>().SetSav(1);
            lancement.GetComponent<Intro>().enabled = true;
            zoom = true;
            menu.Stop();
        }
        if(Input.GetKeyDown(KeyCode.E)&& savechoix == 2 && choix == 1)
        {
            data.GetComponent<DataStorage>().SetSav(2);
            lancement.GetComponent<Intro>().enabled = true;
            zoom = true;
            menu.Stop();
        }
        if(Input.GetKeyDown(KeyCode.E)&& savechoix == 3 && choix == 1)
        {
            data.GetComponent<DataStorage>().SetSav(3);
            lancement.GetComponent<Intro>().enabled = true;
            zoom = true;
            menu.Stop();
        }
        if(Input.GetKeyDown(KeyCode.Space)&& choix == 2)
        {
            save.transform.position = new Vector3(save.transform.position.x,save.transform.position.y,-4);
            transform.position = new Vector3(-4,111.5f,transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.E)&& savechoix == 1 && choix == 2)
        {
            data.GetComponent<DataStorage>().SetSav(1);
            data.GetComponent<DataStorage>().LoadSave();
            lancement.GetComponent<Intro>().enabled = true;
            lancement.GetComponent<Intro>().load = true;
            zoom = true;
            menu.Stop();
        }
        if(Input.GetKeyDown(KeyCode.E)&& savechoix == 2 && choix == 2)
        {
            data.GetComponent<DataStorage>().SetSav(2);
            data.GetComponent<DataStorage>().LoadSave();
            lancement.GetComponent<Intro>().enabled = true;
            lancement.GetComponent<Intro>().load = true;
            zoom = true;
            menu.Stop();
        }
        if(Input.GetKeyDown(KeyCode.E)&& savechoix == 3 && choix == 2)
        {
            data.GetComponent<DataStorage>().SetSav(3);
            data.GetComponent<DataStorage>().LoadSave();
            lancement.GetComponent<Intro>().enabled = true;
            lancement.GetComponent<Intro>().load = true;
            zoom = true;
            menu.Stop();
        }
        if(Input.GetKeyDown(KeyCode.Space)&& choix == 3 && !command)
        {
            explication.transform.position = new Vector3(explication.transform.position.x,explication.transform.position.y,-4);
            command = true;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && choix == 3 && command)
        {
            explication.transform.position = new Vector3(explication.transform.position.x,explication.transform.position.y,-6);
            command = false;
        }
        if(zoom && zoomlevel >= 5.5f){
            zoomlevel -= 0.1f;
            lancement.GetComponent<Camera>().orthographicSize = zoomlevel;
        }
        if(zoom && zoomlevel < 5.5f){
            GetComponent<Menu>().enabled = false;
        }
        if(Input.GetKeyDown(KeyCode.Space) && choix == 4){
        }
    }
}
