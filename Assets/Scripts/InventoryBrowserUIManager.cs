using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBrowserUIManager : MonoBehaviour
{
    [SerializeField] private BrowserItemButton itemButtonPrefab;
    [SerializeField] private RectTransform buttonsParent;
    private InventorySlotsUIManager slotsWindow;
    private PlayerStatsUIManager statsWindow;
    private PlayerCharacterSheet player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerCharacterSheet>();
        slotsWindow = FindObjectOfType<InventorySlotsUIManager>();
        statsWindow = FindObjectOfType<PlayerStatsUIManager>();
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void PopulateWithItemsOfType(Item.ItemType type, int index)
    {
        //first, clear out all the old buttons
        for(int i = 0; i < buttonsParent.childCount; i++)
        {
            Destroy(buttonsParent.GetChild(i).gameObject);
        }

        //then generate new ones for every item of specified type
        foreach(Item item in player.inventory)
        {
            if (item.type == type)
            {
                BrowserItemButton newItem = Instantiate(itemButtonPrefab, buttonsParent);
                newItem.Setup(item, index, player, slotsWindow, statsWindow);
            }
        }
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
