using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private List<EnemyDestroy>[] enemies = new List<EnemyDestroy>[4];

    public enum KeyInputs { up, left, down, right }
    public Chains chains;


    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            enemies[i] = new List<EnemyDestroy>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            FindKeyInput(KeyInputs.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            FindKeyInput(KeyInputs.down);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            FindKeyInput(KeyInputs.right);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            FindKeyInput(KeyInputs.left);
        }
    }

    private void FindKeyInput(KeyInputs key)
    {
        if (enemies[(int)key].Count <= 0)
        {
            chains.LoseChain();
            // hier Attack animation triggern
            SetAttackAnimation();
            // hier fail-Effekt triggern
            return;
        }


        foreach (EnemyDestroy unit in enemies[(int)key])
        {
            GameManager.Instance.killedEnemys++;
            // hier Attack animation triggern
            CheckCharacterDirection(unit.transform.position.x);
            SetAttackAnimation();
            // hier Attack Sound triggern
            unit.OnDeath();
            
        }
        enemies[(int)key].Clear();


        if (GameManager.Instance.killedEnemys == GameManager.Instance.maxEntitiesCount)
        {
            GameManager.Instance.WaveOver = true;
            GameManager.Instance.StartWave();
        }

    }

    public void AddUnit(EnemyDestroy unit)
    {
      
        enemies[(int)unit.MyKeyCode].Add(unit);
    }

    public void SetAttackAnimation()
    {
        GameManager.Instance.playerAnimator.SetTrigger("attack");
    }
    
    private void CheckCharacterDirection(float xPositionEnemy)
    {
        if(xPositionEnemy > transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
