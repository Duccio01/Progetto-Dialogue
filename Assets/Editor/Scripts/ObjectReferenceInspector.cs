using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectReference))]
public class ObjectReferenceInspector : Editor
{
    public override void OnInspectorGUI()
    {
        ObjectReference objectReference = (ObjectReference)target;
        objectReference.customCollider = (Collider)EditorGUILayout.ObjectField("Qualunque collider", objectReference.customCollider, typeof(Collider), true);

        base.OnInspectorGUI();
    }
}
