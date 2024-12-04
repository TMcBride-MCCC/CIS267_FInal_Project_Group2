using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    // Update is called once per frame
    void Update()
    {

    }

    public void updateHealthBar(float currHealth, float maxHealth)
    {
        slider.value = currHealth / maxHealth;
    }
}
