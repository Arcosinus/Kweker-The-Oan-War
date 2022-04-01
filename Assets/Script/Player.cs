using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int sante;
    bool vuln = true;
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
    public Rigidbody2D rb;
    public Animator ame;
    public GameObject energy;
    public GameObject boostHUD;
    public GameObject expression;
    // bool saut = false;
    bool boost = false;
    private Vector3 vel = Vector3.zero;
    public float movespeed;
    public int currentAmmo;
    public int maxAmmo = 10;
    public bool isFiring;
    public Text ammoDisplay;
    private float sautValue = 12f;
    // private float doubleSautValue = 10f;
    private bool doubleSaut;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

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
            IsGrounded();
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
            IsGrounded();
            boost = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Origine = transform.position;
        ambiance.Play();
        ammoDisplay.text = currentAmmo.ToString() + " / " + maxAmmo.ToString();
    }


    void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,0);
        if (transform.position.y <= 16)
        {
            transform.position = Origine;
            takeDamage(2);
            vuln = false;
        }
        if (sante > 0)
        {
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
            if (Input.GetKeyDown(KeyCode.K))
            {
                GameObject attaque;
                attaque = Instantiate(Punch, GetComponent<Transform>());
                attaque.GetComponent<Direction>().enabled = false;
                attaque.GetComponent<Temporary>().enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.I) && !isFiring && currentAmmo > 0)
            {
              fireWeapon();
            }
            void fireWeapon()
            {
              if(currentAmmo > 0)
              {
                isFiring = true;
                currentAmmo--;
                isFiring = false;
                refreshAmmoDisplay(currentAmmo, maxAmmo);
                GameObject attaquetir;
                attaquetir = Instantiate(Tir, GetComponent<Transform>());
                attaquetir.GetComponent<Direction>().enabled = false;
                attaquetir.GetComponent<Temporary>().enabled = true;
              }
              else if(currentAmmo <= 0)
              {
                currentAmmo = 0;
                isFiring = false;
                refreshAmmoDisplay(currentAmmo, maxAmmo);
                // refreshAmmo();
              }
            }
            void refreshAmmoDisplay(int currentAmmo,int maxAmmo)
            {
              ammoDisplay.text = currentAmmo.ToString() + " / " + maxAmmo.ToString();
            }
            if(Input.GetKeyDown(KeyCode.U) && currentAmmo >= 0)
            {
              refreshAmmo();
            }
            void refreshAmmo()
            {
              // isFiring = true;
              // ammoDisplay.text = currentAmmo.ToString() + "/" + maxAmmo.ToString();
              currentAmmo = maxAmmo;
              refreshAmmoDisplay(currentAmmo, maxAmmo);
            }

            if (IsGrounded() && !Input.GetKeyDown(KeyCode.Space) || !Input.GetKeyDown(KeyCode.L))
            {
                doubleSaut = false;
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.L))
            {
                if (IsGrounded() || doubleSaut)
                {
                    // rb.velocity = new Vector2(rb.velocity.x, doubleSaut ? doubleSautValue : sautValue);
                    rb.velocity = new Vector2(rb.velocity.x, sautValue);
                    doubleSaut = !doubleSaut;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            if(!Input.GetKey(KeyCode.DownArrow) || !Input.GetKey(KeyCode.S))
            {
                traversable.GetComponent<Collider2D>().enabled = true;
            }
            if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                traversable.GetComponent<Collider2D>().enabled = false;
            }
            if (Input.GetKey(KeyCode.L))
            {
                traversable.GetComponent<Collider2D>().enabled = false;
            }
            if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.M)&&!(boost))
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
            if (Input.GetKeyDown(KeyCode.R))
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

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
