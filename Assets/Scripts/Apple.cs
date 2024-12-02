using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Apple : MonoBehaviour, ICollectible
{
    public static event HandleGemCollected OnAppleCollected;
    public delegate void HandleGemCollected(ItemData itemData);
    public ItemData greenAppleData;

    public void Collect()
    {
        //Debug.Log("You collected an apple");
        Destroy(gameObject);
        OnAppleCollected?.Invoke(greenAppleData);
    }
}
