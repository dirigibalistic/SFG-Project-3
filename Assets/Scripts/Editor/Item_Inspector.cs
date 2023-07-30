using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CustomEditor(typeof(Item))]
public class Item_Inspector : Editor
{
    public override void OnInspectorGUI()
    {
        Item item = target as Item;
        SerializedObject serializedItem = new SerializedObject(target);
        SerializedProperty statChanges = serializedItem.FindProperty("statChanges");
        serializedItem.Update();

        item.itemName = EditorGUILayout.TextField("Name", item.itemName);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Description");
        item.description = EditorGUILayout.TextArea(item.description);
        EditorGUILayout.EndHorizontal();

        item.icon = (Sprite)EditorGUILayout.ObjectField("Icon", item.icon, typeof(Sprite), false);

        item.type = (Item.ItemType)EditorGUILayout.EnumPopup("Item Type", item.type);
        switch (item.type)
        {
            case Item.ItemType.Head:
            case Item.ItemType.Torso:
            case Item.ItemType.Arms:
            case Item.ItemType.Legs:
                //show armor settings
                item.armor = EditorGUILayout.FloatField("Armor Amount", item.armor);
                EditorGUILayout.PropertyField(statChanges, true);
                break;

            case Item.ItemType.Weapon:
                item.damage = EditorGUILayout.FloatField("Weapon Damage", item.damage);
                EditorGUILayout.PropertyField(statChanges, true);
                break;

            case Item.ItemType.Consumable:

                break;

        }
        serializedItem.ApplyModifiedProperties();
    }
}
