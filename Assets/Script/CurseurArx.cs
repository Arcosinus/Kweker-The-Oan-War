using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CurseurArx : MonoBehaviour
{
    public GameObject info;
    public GameObject etat;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.childCount == 1 && collision.GetComponent<SpriteRenderer>().color != Color.grey)
        {
            name = collision.name;
            info.GetComponent<TextMeshPro>().text = "://" + name + "\n" + collision.transform.GetChild(0).name;
            if (collision.GetComponent<SpriteRenderer>().color == Color.green)
            {
                etat.GetComponent<TextMeshPro>().text = "Sécurisé";
            }
            if (collision.GetComponent<SpriteRenderer>().color == Color.red)
            {
                etat.GetComponent<TextMeshPro>().text = "Inexploré";
            }
        }
        else
        {
            info.GetComponent<TextMeshPro>().text = "://Inaccessible";
            etat.GetComponent<TextMeshPro>().text = "Inexploré";
        }
        if (Input.GetKeyDown(KeyCode.Space) && collision.GetComponent<SpriteRenderer>().color != Color.grey){
            SceneManager.LoadScene(name);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.childCount == 1 && collision.GetComponent<SpriteRenderer>().color != Color.grey)
        {
            name = collision.name;
            info.GetComponent<TextMeshPro>().text = "://" + name + "\n" + collision.transform.GetChild(0).name;
            if (collision.GetComponent<SpriteRenderer>().color == Color.green)
            {
                etat.GetComponent<TextMeshPro>().text = "Sécurisé";
            }
            if (collision.GetComponent<SpriteRenderer>().color == Color.red)
            {
                etat.GetComponent<TextMeshPro>().text = "Inexploré";
            }
        }
        else
        {
            info.GetComponent<TextMeshPro>().text = "://Inaccessible";
            etat.GetComponent<TextMeshPro>().text = "Inexploré";
        }
        if (Input.GetKeyDown(KeyCode.Space) && collision.GetComponent<SpriteRenderer>().color != Color.grey){
            SceneManager.LoadScene(name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        info.GetComponent<TextMeshPro>().text = "://Analyse";
        etat.GetComponent<TextMeshPro>().text = "";
    }
    private Vector3 vel = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Animator ame = GetComponent<Animator>();
        float Xmov = Input.GetAxis("Horizontal") * 3;
        float Ymov = Input.GetAxis("Vertical") * 3;
        Vector3 mouv = new Vector2(Xmov, Ymov);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, mouv, ref vel, 0.05f);
        ame.SetFloat("Move", Xmov);
        if (Xmov == 0){
            ame.SetFloat("Move", Ymov);
        }
        if (transform.position.x >= 6.2f)
        {
            transform.position = new Vector3(-5.8f,transform.position.y,transform.position.z);
        }
        if (transform.position.x <= -5.9f)
        {
            transform.position = new Vector3(6.1f,transform.position.y,transform.position.z);
        }
        if (transform.position.y <= -4)
        {
            transform.position = new Vector3(transform.position.x,4.3f,transform.position.z);
        }
        if (transform.position.y >= 4.4f)
        {
            transform.position = new Vector3(transform.position.x,-3.9f,transform.position.z);
        }
    }
}
