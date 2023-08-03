using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CustomEditor(typeof(PlayerCharacterSheet))]
public class PlayerCharacterSheet_Inspector : Editor
{
    [SerializeField] private VisualTreeAsset tree;

    public override VisualElement CreateInspectorGUI()
    {
        var sheet = target as PlayerCharacterSheet;
        var container = new VisualElement();

        container.Add(tree.Instantiate());

        container.Query<Button>("update").First().clicked += sheet.UpdateStats;

        return container;
    }
}
