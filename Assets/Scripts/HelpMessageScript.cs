using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMessageScript : MonoBehaviour
{
    private float timer = 3f;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
