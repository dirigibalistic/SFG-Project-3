using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotsUIManager : MonoBehaviour
{
    [SerializeField] private ItemSlotButton slotButtonPrefab;
    private InventoryBrowserUIManager browser;
    private PlayerCharacterSheet player;

    private void Awake()
    {
        browser = FindObjectOfType<InventoryBrowserUIManager>();
        player = FindObjectOfType<PlayerCharacterSheet>();
    }

    private void Start()
    {
        PopulateSlotList();
    }

    public void PopulateSlotList()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }

        int index = 0;
        foreach (Item item in player.inventorySlots)
        {
            ItemSlotButton newSlot = Instantiate(slotButtonPrefab, gameObject.transform);
            newSlot.Setup(item, index, browser);
            index++;
        }
    }
}
