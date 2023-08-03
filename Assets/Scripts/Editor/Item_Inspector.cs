using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CustomEditor(typeof(Item))]
public class Item_Inspector : Editor
{
    [SerializeField] private VisualTreeAsset tree;

    public override VisualElement CreateInspectorGUI()
    {
        var container = new VisualElement();

        container.Add(tree.Instantiate());

        return container;
    }
}