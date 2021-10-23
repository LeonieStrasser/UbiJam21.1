using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chains : MonoBehaviour
{
    int chains;
    int maxChains = 5;

    public GameObject cp1;
    public GameObject cp2;
    public GameObject cp3;
    public GameObject cp4;
    public GameObject cp5;

    public float damageDelayTime = 1;

    public Gamemanager gm;



    // Start is called before the first frame update
    void Start()
    {
        chains = maxChains;
        gm = FindObjectOfType<Gamemanager>();
        
    }



    public void LoseChain()
    {
        chains--;

        // Health Sprites aktualisieren
        switch (chains)
        {
            case 4:
                cp1.SetActive(true);
                cp2.SetActive(true);
                cp3.SetActive(true);
                cp4.SetActive(true);
                cp5.SetActive(false);
                break;

            case 3:
                cp1.SetActive(true);
                cp2.SetActive(true);
                cp3.SetActive(true);
                cp4.SetActive(false);
                cp5.SetActive(false);
                break;

            case 2:
                cp1.SetActive(true);
                cp2.SetActive(true);
                cp3.SetActive(false);
                cp4.SetActive(false);
                cp5.SetActive(false);
                break;

            case 1:
                cp1.SetActive(true);
                cp2.SetActive(false);
                cp3.SetActive(false);
                cp4.SetActive(false);
                cp5.SetActive(false);
                break;

            case 0:
                cp1.SetActive(false);
                cp2.SetActive(false);
                cp3.SetActive(false);
                cp4.SetActive(false);
                cp5.SetActive(false);

                gm.GameIsOver();
                break;
        }

    }

   
}
