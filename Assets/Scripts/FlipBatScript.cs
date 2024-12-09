using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipBatScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        flipBatSprite();
    }

    private void flipBatSprite()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");

        if (inputVertical != 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (inputHorizontal > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, -15);
        }
        else if (inputHorizontal < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 15);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, -15);
        }
    }
}
