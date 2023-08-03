using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "ITM_")]
public class Item : ScriptableObject
{
    public string itemName;
    public string description;

    public ItemType type;
    public Sprite icon;

    public StatChange[] statChanges = new StatChange[0];

    public enum ItemType
    {
        Head,
        Torso,
        Arms,
        Legs,
        Weapon,
    }
}