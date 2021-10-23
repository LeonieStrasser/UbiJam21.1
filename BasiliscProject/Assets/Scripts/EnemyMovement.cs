using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;

    public Gamemanager gm;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<Gamemanager>();
        rb = this.GetComponent<Rigidbody2D>();
        // speed = gm.currentSpeed; ------- warum kann das Script nicht auf gm.currentSpeed zugreifen???
        rb.velocity = new Vector2(-speed, 0f);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
