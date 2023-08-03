using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CustomPropertyDrawer(typeof(PlayerStatValue))]
public class PlayerStatValue_PropertyDrawer : PropertyDrawer
{
    private VisualTreeAsset tree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/Editor/PlayerStatValue_Tree.uxml");

    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var container = new VisualElement();

        container.Add(tree.Instantiate());

        return container;
    }
}
