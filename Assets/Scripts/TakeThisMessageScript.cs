using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeThisMessageScript : MonoBehaviour
{
    private float timer = 6f;
    private float timer2 = 12f;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timer2 -= Time.deltaTime;

        if (timer <= 0f)
        {
            spriteRenderer.enabled = true;
        }

        if (timer2 <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
