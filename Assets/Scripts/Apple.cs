using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour, ICollectible
{
    public static event HandleAppleCollected OnAppleCollected;
    public delegate void HandleAppleCollected(ItemData itemData);
    public ItemData greenAppleData;

    public void Collect()
    {
        //Debug.Log("You collected an apple");
        Destroy(gameObject);
        OnAppleCollected?.Invoke(greenAppleData);
    }
}
