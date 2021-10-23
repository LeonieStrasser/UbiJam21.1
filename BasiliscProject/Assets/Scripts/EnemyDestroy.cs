using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private PlayerInput.KeyInputs myKeyCode;
    public PlayerInput.KeyInputs MyKeyCode { get => this.myKeyCode; }

    public IconSprite icon;

    [Min(0f)]
    [SerializeField] private float deathDelay = 0.5f;
    
    
    void Start()
    {
       
        SetKeyCode();
        GameManager.Instance.OnUnitSpawn(this);
       
    }

   
    

    void SetKeyCode()
    {
        int randomNumber = Random.Range(0, 4);

        switch(randomNumber)
        {
            case 0:
                myKeyCode = PlayerInput.KeyInputs.up;
                icon.SetUpSprite();
                break;

            case 1:
                myKeyCode = PlayerInput.KeyInputs.down;
                icon.SetDownSprite();
                break;

            case 2:
                myKeyCode = PlayerInput.KeyInputs.left;
                icon.SetLeftSprite();
                break;

            case 3:
                myKeyCode = PlayerInput.KeyInputs.right;
                icon.SetRightSprite();
                break;

            default:
                Debug.Log("Random generation of KeyCode failed!");
                break;
        }
    }

    public void OnDeath()
    {
        
        
        Destroy(gameObject, deathDelay);
    }
}
