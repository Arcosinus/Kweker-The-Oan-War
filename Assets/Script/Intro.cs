using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public bool load = false;
    bool finintro = true;
    bool preintro = true;
    public AudioSource intromusique;
    public Transform cabine;
    public Transform titre;
    public Transform skip;
    // Start is called before the first frame update
    void Start()
    {
        intromusique.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (finintro && preintro && transform.position.y >= 77)
        {
            transform.Translate(0,-0.055f,0);
            cabine.Translate(0,-0.05f,0);
        }
        if (transform.position.y <= 77 && !load)
        {
            finintro = false;
            preintro = false;
            titre.transform.position = new Vector3(titre.transform.position.x,titre.transform.position.y,0);
        }
        else if (transform.position.y <= 77 && load)
        {
            SceneManager.LoadScene("Map");
        }
        if (Input.anyKeyDown && transform.position.y >= 57.5f && transform.position.y <= 77)
        {
            skip.position = new Vector3(skip.position.x,skip.position.y,-4);
        }
        if (Input.GetKey(KeyCode.Space) && !finintro && transform.position.y >= 57.5f)
        {
            transform.position = new Vector3(transform.position.x,57.5f,transform.position.z);
            skip.position = new Vector3(skip.position.x,skip.position.y,-10);
            finintro = true;
            preintro = true;
        }
        if (transform.position.y >= 57.5f && !finintro)
        {
            transform.Translate(0,-0.001f,0);
            cabine.Translate(0,-0.00125f,0);
        }
        if (transform.position.y <= 57.5f && !finintro)
        {
            SceneManager.LoadScene("Base");
        }
        if (!finintro)
        {
            finintro = true;
        }
    }
}

