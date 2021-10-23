using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int health;
    int maxHealth = 3;

    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;

    public float damageDelayTime = 1;

    public Gamemanager gm;

    
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        gm = FindObjectOfType<Gamemanager>();
        gm.collisionAktive = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy")
        {
            gm.collisionAktive = true;
            Damage();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        StartCoroutine(DamageDelay());
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy")
        {
            gm.collisionAktive = false;
        }
    }



    public void Damage()
    {
        health--;

        // Health Sprites aktualisieren
        switch(health)
        {
            case 2:
                hp1.SetActive(true);
                hp2.SetActive(true);
                hp3.SetActive(false);
                break;

            case 1:
                hp1.SetActive(true);
                hp2.SetActive(false);
                hp3.SetActive(false);
                break;

            case 0:
                hp1.SetActive(false);
                hp2.SetActive(false);
                hp3.SetActive(false);

                gm.GameIsOver();
                break;
        }
            
    }

    IEnumerator DamageDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(damageDelayTime);
            
            if(gm.collisionAktive == true)
            {
                Damage();
            }
            else { 
                Debug.Log("No Enemy after Delay");
                break;
            }
            
        }

    }
}
