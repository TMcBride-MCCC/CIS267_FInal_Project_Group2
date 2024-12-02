using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Apple : MonoBehaviour, ICollectible
{
    public static event Action OnAppleCollected;

    public void Collect()
    {
        Debug.Log("You collected an apple");
        Destroy(gameObject);
        OnAppleCollected?.Invoke();
    }
}
