using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piège : MonoBehaviour
{
    public bool piege;
    public GameObject porte;
    public GameObject[] adversaire;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if(piege)
            {
                porte.GetComponent<Portepiege>().Setcapt(true);
            }
            else
            {
                porte.GetComponent<Portepiege>().Setcapt(false);
            }
        }
    }

    void Update()
    {
        piege = false;
        int i = 0;
        while (i != adversaire.Length)
        {
            if(adversaire[i])
            {
                piege = true;
            }
            i++;
        }
    }
}
