using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int sante;
    public bool vuln = true;
    int invincTime = 0;
    public int gameOver = 0;
    Vector3 Origine;
    public AudioSource ambiance;
    public AudioSource fingame;
    public GameObject traversable;
    public GameObject Gameover;
    public GameObject Gameover2;
    public GameObject Gameover3;
    public GameObject Gameover4;
    public GameObject Gameover5;
    public GameObject Cam;
    Color fondu;
    Color Mosaica;
    Transform ActualCheck;
    public GameObject Punch;
    public GameObject Tir;
    public GameObject Napalm;
    public Rigidbody2D rb;
    public Animator ame;
    public GameObject energy;
    public GameObject boostHUD;
    public GameObject[] munition;
    public GameObject expression;
    public string W1;
    public string W2;
    bool saut = false;
    bool boost = false;
    private Vector3 vel = Vector3.zero;
    public float movespeed;
    float forceY;
    float oldY;
    int wait;
    int munit;
    int wmunit = 0;
    public int munitionDispo = 3;
    int i = 0;
    public int GetSante()
    {
        return sante;
    }
    public string GetW1()
    {
        return W1;
    }
    public string GetW2()
    {
        return W2;
    }
    public void SetSante(int newS)
    {
        sante = newS;
    }
    public void SetW1(string newW)
    {
        W1 = newW;
    }
    public void SetW2(string newW)
    {
        W2 = newW;
    }
    public void takeDamage(int dmg)
    {
        if (sante != 0)
        {
            if (vuln == true)
            {
                sante -= dmg;
                vuln = false;
            }
        }
    }
    public void healDamage(int soin)
    {
        if (sante != 0)
        {
            if (sante < 16)
            {
                sante += soin;
                if (sante > 16){
                    sante = 16;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Respawn"))
        {
            if (!(ActualCheck is null))
            {
                ActualCheck.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            Origine = transform.position;
            ActualCheck = collision.transform;
            ActualCheck.GetComponent<SpriteRenderer>().color = Color.green;
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Level"))
        {
            saut = false;
            boost = false;
        }
        if (collision.transform.CompareTag("Ennemy"))
        {
            Vector3 repouss = (collision.transform.position - transform.position) * -0.1f;
            transform.Translate(repouss.normalized,Space.World);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Level"))
        {
            saut = false;
            boost = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Nweapon1")&& W2 == "Napalm")
        {
            GameObject.Find("Nweapon1").GetComponent<SpriteRenderer>().color = Color.white;
        }
        if(GameObject.Find("Data"))
        {
            GameObject.Find("Data").GetComponent<DataStorage>().SetData();
        }
        Origine = transform.position;
        ambiance.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        transform.position = new Vector3(transform.position.x,transform.position.y,0);
        if (transform.position.y <= 16)
        {
            transform.position = Origine;
            takeDamage(2);
            vuln = false;
        }
        if (sante > 0)
        {
            if (W2 == "Napalm")
            {
                munition[0].GetComponent<SpriteRenderer>().color = Color.grey;
                munition[1].GetComponent<SpriteRenderer>().color = Color.grey;
                munition[2].GetComponent<SpriteRenderer>().color = Color.grey;
                if (munitionDispo == 3)
                {
                    munition[0].GetComponent<SpriteRenderer>().color = Color.red;
                    munition[1].GetComponent<SpriteRenderer>().color = Color.red;
                    munition[2].GetComponent<SpriteRenderer>().color = Color.red;
                }
                else if (munitionDispo == 2)
                {
                    munition[0].GetComponent<SpriteRenderer>().color = Color.red;
                    munition[1].GetComponent<SpriteRenderer>().color = Color.red;
                }
                else if (munitionDispo == 1)
                {
                    munition[0].GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
            else
            {
                munition[0].GetComponent<SpriteRenderer>().color = new Vector4(0,255,255,255);
                munition[1].GetComponent<SpriteRenderer>().color = new Vector4(0,255,255,255);
                munition[2].GetComponent<SpriteRenderer>().color = new Vector4(0,255,255,255);
            }
            if (munit > 0)
            {
                wmunit--;
                if (wmunit <= 0)
                {
                GameObject attaquetir;
                attaquetir = Instantiate(Napalm);
                attaquetir.transform.position = transform.position;
                attaquetir.GetComponent<Direction>().enabled = false;
                attaquetir.GetComponent<Temporary>().enabled = true;
                munit--;
                wmunit = 5;
                }
            }
            if (boost)
            {
                boostHUD.GetComponent<SpriteRenderer>().color = Color.grey;
            }
            else
            {
                boostHUD.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            if (vuln == false)
            {
                if (GetComponent<SpriteRenderer>().color == Color.white)
                {
                GetComponent<SpriteRenderer>().color = Color.red;
                energy.GetComponent<SpriteRenderer>().color = Color.red;
                expression.GetComponent<SpriteRenderer>().color = Color.red;
                } 
                else 
                {
                GetComponent<SpriteRenderer>().color = Color.white;
                energy.GetComponent<SpriteRenderer>().color = Color.white;
                expression.GetComponent<SpriteRenderer>().color = Color.white;
                }
                if (invincTime >= 100)
                {
                    vuln = true;
                    invincTime = 0;
                }
                invincTime++;
            } 
            else 
            {
                GetComponent<SpriteRenderer>().color = Color.white;
                energy.GetComponent<SpriteRenderer>().color = Color.white;
                expression.GetComponent<SpriteRenderer>().color = Color.white;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject attaque;
                attaque = Instantiate(Punch,GetComponent<Transform>());
                attaque.GetComponent<Direction>().enabled = false;
                attaque.GetComponent<Temporary>().enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameObject attaquetir;
                attaquetir = Instantiate(Tir);
                attaquetir.transform.position = transform.position;
                attaquetir.GetComponent<Direction>().enabled = false;
                attaquetir.GetComponent<Temporary>().enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.T)&& W2 == "Napalm"  && munitionDispo > 0)
            {
                munitionDispo--;
                munit = 5;
            }
            if (Input.GetKeyDown(KeyCode.G)&&!(saut))
            {
                rb.AddForce(new Vector2(0,300f));
                saut = true;
            }
            if(!Input.GetKey(KeyCode.DownArrow) || !Input.GetKey(KeyCode.S))
            {
                traversable.GetComponent<Collider2D>().enabled = true;
            }
            if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                traversable.GetComponent<Collider2D>().enabled = false;
            }
            if (wait >= 10)
            {
                forceY = transform.position.y - oldY;
                oldY = transform.position.y;
                wait = 0;
            }
            if (forceY>0)
            {
                traversable.GetComponent<Collider2D>().enabled = false;
            }
            wait++;
            if (Input.GetKeyDown(KeyCode.H)&&!(boost))
            {
                if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.S))
                {
                    rb.AddForce(new Vector2(0,-500f));
                } 
                else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.A))
                {
                    rb.AddForce(new Vector2(-3000f,0));
                } 
                else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.D))
                {
                    rb.AddForce(new Vector2(3000f,0));
                } 
                else 
                {
                    rb.AddForce(new Vector2(0,300f));
                }
                boost = true;
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                transform.position = Origine;
            }
            float Xmov = Input.GetAxis("Horizontal") * movespeed;
            Vector3 mouv = new Vector2(Xmov, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, mouv, ref vel, 0.05f);
            ame.SetFloat("Move", Xmov);
        }
        ame.SetInteger("Sante", sante);
        energy.GetComponent<Animator>().SetInteger("Sante", sante);
        expression.GetComponent<Animator>().SetInteger("Sante", sante);
        if (sante == 0)
        {
            ambiance.Stop();
            if (gameOver == 350)
            {
                fingame.Play();
                fondu = Color.blue;
                Mosaica = Color.white;
                fondu.a = 0;
                Mosaica.a = 0;
                Gameover.transform.position = new Vector3(Gameover.transform.position.x,Gameover.transform.position.y,-4);
                Gameover2.GetComponent<SpriteRenderer>().color = Mosaica;
                Gameover3.GetComponent<SpriteRenderer>().color = Mosaica;
                Gameover4.GetComponent<SpriteRenderer>().color = Mosaica;
                Gameover5.GetComponent<SpriteRenderer>().color = Mosaica;
                gameOver++;
            } 
            else if (gameOver <= 400)
            {
                fondu.a += 0.1f;
                Mosaica.a += 0.1f;
                Gameover.GetComponent<SpriteRenderer>().color = fondu;
                gameOver++;
            } 
            else if (gameOver <= 500)
            {
                fondu.b -= 0.025f;
                Gameover.GetComponent<SpriteRenderer>().color = fondu;
                Gameover2.GetComponent<SpriteRenderer>().color = fondu;
                Gameover3.GetComponent<SpriteRenderer>().color = fondu;
                Gameover4.GetComponent<SpriteRenderer>().color = Mosaica;
                Gameover5.GetComponent<SpriteRenderer>().color = Mosaica;
                gameOver++;
            } 
            else if (gameOver >= 550)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Gameover.transform.position = new Vector3(Gameover.transform.position.x,Gameover.transform.position.y,-6);
                    sante = 16;
                    transform.position = Origine;
                    gameOver = 0;
                    fingame.Stop();
                    ambiance.Play();
                }
            }
            else 
            {
                Gameover.GetComponent<SpriteRenderer>().color = fondu;
                Gameover2.GetComponent<SpriteRenderer>().color = fondu;
                Gameover3.GetComponent<SpriteRenderer>().color = fondu;
                gameOver++;
            }
        }
    }
}
