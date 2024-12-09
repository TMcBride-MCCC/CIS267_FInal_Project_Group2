using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DidYouHearThatScript : MonoBehaviour
{
    private float timer = 3f;
    private float timer2 = 10f;
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
