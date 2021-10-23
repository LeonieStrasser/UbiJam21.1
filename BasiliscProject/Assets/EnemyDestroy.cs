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
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        up = KeyCode.UpArrow;
        down = KeyCode.DownArrow;
        left = KeyCode.LeftArrow;
        right = KeyCode.RightArrow;

        SetKeyCode();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(myKeyCode))
        {
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
                break;

            case 2:
                myKeyCode = down;
                break;

            case 3:
                myKeyCode = left;
                break;

            case 4:
                myKeyCode = right;
                break;

            default:
                Debug.Log("Random generation of KeyCode failed!");
                break;
        }
    }
}
