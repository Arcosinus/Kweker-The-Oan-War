using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CurseurArx : MonoBehaviour
{
    public TextMeshProUGUI info;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.childCount == 1)
        {
            name = collision.name;
            info.GetComponent<TextMeshProUGUI>().text = "://" + name + "\n" + collision.transform.GetChild(0).name;
        }
        else
        {
            name = collision.name;
            info.GetComponent<TextMeshProUGUI>().text = "://" + name;
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene(name);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.childCount == 1)
        {
            name = collision.name;
            info.GetComponent<TextMeshProUGUI>().text = "://" + name + "\n" + collision.transform.GetChild(0).name;
        }
        else
        {
            name = collision.name;
            info.GetComponent<TextMeshProUGUI>().text = "://" + name;
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene(name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        info.GetComponent<TextMeshProUGUI>().text = "://Analyse";
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
    }
}
