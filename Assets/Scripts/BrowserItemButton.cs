using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BrowserItemButton : MonoBehaviour
{
    [SerializeField] private Image IconImageObject;
    [SerializeField] private TextMeshProUGUI NameTextObject;
    [SerializeField] private TextMeshProUGUI DescriptionTextObject;
    private Item buttonItem;
    private PlayerCharacterSheet playerSheet;
    private int slotIndex;
    private InventorySlotsUIManager slotsWindow;
    private PlayerStatsUIManager statsWindow;

    public void Setup(Item item, int index, PlayerCharacterSheet player, InventorySlotsUIManager slotsManager, PlayerStatsUIManager statsManager)
    {
        IconImageObject.sprite = item.icon;
        NameTextObject.text = item.itemName;
        DescriptionTextObject.text = item.description;
        buttonItem = item;
        slotIndex = index;
        playerSheet = player;
        slotsWindow = slotsManager;
        statsWindow = statsManager;
    }

    public void OnButtonPressed()
    {
        playerSheet.EquipItem(slotIndex, buttonItem);
        slotsWindow.PopulateSlotList();
        statsWindow.updateAllWidgets();
        GetComponentInParent<InventoryBrowserUIManager>().CloseWindow();
    }
}