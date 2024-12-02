using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatlhBar : MonoBehaviour
{
    public PlayerController player;
    public Image fillImage;
    private Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillValue = (float)player.currHealth / player.maxHealth;
        
        //Debug.Log(fillValue);
        slider.value = fillValue;
    }
}
