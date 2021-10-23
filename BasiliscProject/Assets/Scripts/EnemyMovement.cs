using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    [SerializeField]private Rigidbody2D rb;

   

    public void Init(float speed)
    {
        rb.velocity = new Vector2(speed, 0f);
    }
    
}
