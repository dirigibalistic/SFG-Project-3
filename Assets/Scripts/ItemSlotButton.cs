using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlotButton : MonoBehaviour
{
    [SerializeField] private Image IconImageObject;
    [SerializeField] private TextMeshProUGUI NameTextObject;
    private Item.ItemType slotType;
    private int slotIndex;
    private InventoryBrowserUIManager browserWindow;

    public void Setup(Item item, int index, InventoryBrowserUIManager browser)
    {
        IconImageObject.sprite = item.icon;
        NameTextObject.text = item.itemName;
        slotType = item.type;
        slotIndex = index;
        browserWindow = browser;
    }

    public void OnButtonPressed()
    {
        browserWindow.gameObject.SetActive(true);
        browserWindow.PopulateWithItemsOfType(slotType, slotIndex);
    }
}