using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI stackSizeText;

    public void DrawSlot(InventoryItem item)
    {
        if (item == null)
        {
            ClearSlot();
            return;
        }

        FillSlot(item);
    }
    public void ClearSlot()
    {
        icon.enabled = false;
        stackSizeText.enabled = false;
    }

    public void FillSlot(InventoryItem item)
    {
        icon.enabled = true;
        stackSizeText.enabled = true;
        
        icon.sprite = item.ItemData.icon;
        stackSizeText.text = "x" + item.stackSize.ToString();
    }
}
