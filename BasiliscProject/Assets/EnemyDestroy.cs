using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    KeyCode up;
    KeyCode down;
    KeyCode left;
    KeyCode right;

    KeyCode myKeyCode;

    public IconSprite icon;

    public Gamemanager gm;
    
    
    // Start is called before the first frame update
    void Start()
    {
        up = KeyCode.UpArrow;
        down = KeyCode.DownArrow;
        left = KeyCode.LeftArrow;
        right = KeyCode.RightArrow;

        SetKeyCode();

        gm = FindObjectOfType<Gamemanager>();

        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(myKeyCode))
        {
            gm.killedEnemys++;



            if (gm.killedEnemys - 2 == gm.nrOfEnemys1)
            {
                gm.wave1Over = true;
                gm.WaveController();
            }
            Destroy(gameObject);
        }
    }

    void SetKeyCode()
    {
        int randomNumber = Random.Range(1, 4);

        switch(randomNumber)
        {
            case 1:
                myKeyCode = up;
                icon.SetUpSprite();
                break;

            case 2:
                myKeyCode = down;
                icon.SetDownSprite();
                break;

            case 3:
                myKeyCode = left;
                icon.SetLeftSprite();
                break;

            case 4:
                myKeyCode = right;
                icon.SetRightSprite();
                break;

            default:
                Debug.Log("Random generation of KeyCode failed!");
                break;
        }
    }
}
