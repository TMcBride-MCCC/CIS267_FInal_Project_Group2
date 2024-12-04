using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballBat : MonoBehaviour, ICollectible
{
    public static event HandleBatCollected OnBatCollected;
    public delegate void HandleBatCollected(ItemData itemData);
    public ItemData baseballBatData;

    public void Collect()
    {
        Debug.Log("You collected the bat");
        Destroy(gameObject);
        OnBatCollected?.Invoke(baseballBatData);
    }
}