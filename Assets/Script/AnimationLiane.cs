using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLiane : MonoBehaviour
{
    Vector3 origine;
    public bool alert;
    int croissance;
    int décroissance;
    int i;
    public float Angle;
    public float DestAngle;
    // Start is called before the first frame update
    void Start()
    {
        origine = transform.position;
        alert = true;
        croissance = 0;
        décroissance = 0;
        i = 0;
    }

    // Update is called once per frame
    async void Update()
    {
        float Trigo = transform.position.x + GameObject.Find("Arxcoz").transform.position.x;
        float Hauteur = transform.position.y + GameObject.Find("Arxcoz").transform.position.y;
        Angle = Hauteur/Trigo;
        if (Hauteur > 0)
        {
            DestAngle = Angle * -1f;
        }
        if (Trigo > 0 && Hauteur < 0)
        {
            DestAngle = 180 - Angle;
        }
        if (Trigo > 0 && Hauteur > 0)
        {
            DestAngle = 180 + Angle;
        }
        transform.rotation = new Quaternion(0,0,DestAngle,1);
        if (alert)
        {
            croissance++;
            Vector3 repouss = (transform.position - GameObject.Find("Arxcoz").transform.position) / -5;
            transform.Translate(repouss,Space.World);
            if (Vector3.Distance(transform.position,GameObject.Find("Arxcoz").transform.position) < 1f)
            {
                alert = false;
                croissance = 0;
            }
            if(croissance >= 1)
            {
                croissance = 0;
                GameObject part;
                part = Instantiate(GameObject.Find("Liane"));
                part.name = "Liane" + i;
                part.transform.rotation = new Quaternion(0,0,DestAngle,1);
                i++;
                part.transform.position = transform.position;
            }
        }
        else
        {
            décroissance++;
            Vector3 repouss = (transform.position - origine) / -5;
            transform.Translate(repouss.normalized,Space.World);
            if(décroissance >= 1)
            {
                i--;
                Destroy(GameObject.Find("Liane" + i));
            }
            if (Vector3.Distance(transform.position,origine) < 1f)
            {
                décroissance = 0;
                alert = true;
                while (i > 0)
                {
                    i--;
                    Destroy(GameObject.Find("Liane" + i));
                }
                Destroy(gameObject);
            }
        }
    }
}
