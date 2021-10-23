using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    public EnemyDestroy ed;
    public SpriteRenderer iconSpriteRenderer;

    private void Start()
    {
        ed = GetComponent<EnemyDestroy>()!;
        iconSpriteRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ed.enabled = true;
            iconSpriteRenderer.enabled = true;
        }
    }
}
