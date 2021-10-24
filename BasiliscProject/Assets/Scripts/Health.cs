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

    

    
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
       
        GameManager.Instance.collisionAktive = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy")
        {
            GameManager.Instance.collisionAktive = true;
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
            GameManager.Instance.collisionAktive = false;
        }
    }



    public void Damage()
    {
        health--;
        AudioManager.instance.PlaySound(GameManager.Instance.Soundname_damage);
        AudioManager.instance.PlaySound(GameManager.Instance.Soundname_Hit);

        // Health Sprites aktualisieren
        switch (health)
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

                GameManager.Instance.GameIsOver();
                break;
        }
            
    }

    IEnumerator DamageDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(damageDelayTime);
            
            if(GameManager.Instance.collisionAktive == true)
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
