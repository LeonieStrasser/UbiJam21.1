using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chains : MonoBehaviour
{
    int chains;
   


    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public float damageDelayTime = 1;

    


    // Start is called before the first frame update
    void Start()
    {
        chains = sprites.Length;
        spriteRenderer.sprite = sprites[chains - 1];
    }



    public void LoseChain()
    {
        chains--;
        if (chains - 1 < 0)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.sprite = sprites[chains - 1];
        }

        if (chains <= 0)
        {
            GameManager.Instance.GameIsOver();
        }


    }


}
