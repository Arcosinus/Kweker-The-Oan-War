using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fermeture : MonoBehaviour
{
    public GameObject porte;
    bool bossF;
    public GameObject boss;
    public AudioSource ost;
    public AudioSource ambiance;
    public GameObject sante;
    public bool bossAlive = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            bossF = true;
            ost.Play();
            ambiance.Stop();
            sante.transform.position = new Vector3(sante.transform.position.x,sante.transform.position.y,-3);
            sante.GetComponent<TextMeshPro>().text = "sante : 60";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            bossF = false;
            ost.Stop();
            ambiance.Play();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bossF && porte.transform.position.y > 3 && bossAlive)
        {
            porte.transform.Translate(0,-0.01f,0);
        }
        else if (porte.transform.position.y <= 3)
        {
            boss.GetComponent<Boss1>().enabled = true;
        }
        if (!bossF)
        {
            sante.transform.position = new Vector3(sante.transform.position.x,sante.transform.position.y,-6);
            porte.transform.position = new Vector3(0,6,0);
            boss.GetComponent<Boss1>().enabled = false;
            boss.GetComponent<Boss1>().sante = 60;
            boss.transform.position = new Vector3(20.75f,23.5f,0);
        }
        if (!bossAlive)
        {
            porte.transform.position = new Vector3(0,6,0);
        }
    }
}
