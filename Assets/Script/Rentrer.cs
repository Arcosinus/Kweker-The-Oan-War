using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rentrer : MonoBehaviour
{
    public GameObject play;
    public GameObject cam;
    public GameObject porte;
    public GameObject camouflage;
    public GameObject[] Access;
    public AudioSource ground;
    public AudioSource waiting;
    public AudioSource vaisseau;
    public GameObject fondu;
    bool musique = true;
    bool retour = false;
    bool entrer = true;
    bool fast = false;
    public void retourvaisseau(){
        if (Input.GetKeyDown(KeyCode.Space)&&fast){
            transform.position = new Vector3(0,70,transform.position.z);
            play.transform.position = new Vector3(-16,95,play.transform.position.z);
            fast = false;
            fondu.GetComponent<GestionWait>().waitScreen(3);
        }
    }
    public void sortievaisseau(){
        if (Input.GetKeyDown(KeyCode.Space)&&fast){
            transform.position = new Vector3(0,10,transform.position.z);
            play.transform.position = new Vector3(-16.65f,35.15f,play.transform.position.z);
            fast = false;
            fondu.GetComponent<GestionWait>().waitScreen(3);
        }
    }
    private void OnCollisionStay2D(Collision2D collision){
        if (collision.transform.CompareTag("Player")){
            if (Input.GetKeyDown(KeyCode.E)){
                if (retour == false){
                    ground.Stop();
                    waiting.Play();
                    musique = false;
                    retour = true;
                    entrer = false;
                    fast = true;
                    camouflage.GetComponent<Collider2D>().enabled = false;
                    Access[0].transform.position = new Vector3(-19.25f,23.3f,Access[0].transform.position.z);
                    Access[0].transform.Rotate(0,0,-135,Space.Self);
                    Access[1].transform.position = new Vector3(-13.75f,23.3f,Access[1].transform.position.z);
                    Access[1].transform.Rotate(0,0,135,Space.Self);
                } else if (entrer == false){
                    vaisseau.Stop();
                    waiting.Play();
                    musique = false;
                    retour = false;
                    entrer = true;
                    fast = true;
                    camouflage.GetComponent<Collider2D>().enabled = false;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (retour == true){
            porte.GetComponent<Collider2D>().enabled = false;
            if (transform.position.y < 80){
                porte.GetComponent<Collider2D>().enabled = true;
                play.transform.position = new Vector3(play.transform.position.x,play.transform.position.y+0.02f,play.transform.position.z);
                transform.position = new Vector3(transform.position.x,transform.position.y+0.02f,transform.position.z);
                retourvaisseau();
            }
            if (transform.position.y >= 80){
                waiting.Stop();
                camouflage.GetComponent<Collider2D>().enabled = true;
                if (musique == false)
                {
                    vaisseau.Play();
                    musique = true;
                }
            }
        }
        if (entrer == true){
            porte.GetComponent<Collider2D>().enabled = false;
            if (transform.position.y > 0){
                porte.GetComponent<Collider2D>().enabled = true;
                play.transform.position = new Vector3(play.transform.position.x,play.transform.position.y-0.02f,play.transform.position.z);
                transform.position = new Vector3(transform.position.x,transform.position.y-0.02f,transform.position.z);
                sortievaisseau();
            }
            if (transform.position.y <= 0){
                camouflage.GetComponent<Collider2D>().enabled = true;
                waiting.Stop();
                if (musique == false)
                {
                    Access[0].transform.position = new Vector3(-20,24,Access[0].transform.position.z);
                    Access[0].transform.Rotate(0,0,135,Space.Self);
                    Access[1].transform.position = new Vector3(-13,24,Access[1].transform.position.z);
                    Access[1].transform.Rotate(0,0,-135,Space.Self);
                    musique = true;
                    ground.Play();
                }
            }
        }
    }
}
