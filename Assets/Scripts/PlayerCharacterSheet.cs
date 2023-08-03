using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterSheet : MonoBehaviour
{
    public PlayerStatValue[] stats;
    public float currentHealth;
    private float maxHealth;

    public Item[] inventorySlots;
    public List<Item> inventory;

    private void Awake()
    {
        UpdateStats();
    }

    public void EquipItem(int index, Item itemToEquip)
    {
        inventorySlots[index] = itemToEquip;

        UpdateStats();
    }

    public void UpdateStats()
    {
        foreach (PlayerStatValue stat in stats)
        {
            stat.totalValue = stat.baseValue;
            foreach(Item item in inventorySlots)
            {
                foreach(StatChange change in item.statChanges)
                {
                    if (change.name == stat.name)
                    {
                        stat.totalValue += change.value;
                    }
                }
            }
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
