using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectible collectable = collision.GetComponent<ICollectible>();
        if (collectable != null )
        {
            collectable.Collect();
        }
    }
}
