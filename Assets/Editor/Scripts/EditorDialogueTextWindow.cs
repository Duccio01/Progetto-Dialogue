using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EditorDialogueTextWindow : EditorWindow
{
    public string lineName;
    public string dialgogueLineContent;
    public bool confirm;
    public int selectedColor;
    public string[] colorOptions = new string[] { "White", "Red", "Blue", "Yellow", "Green", "Black" };
    public Color dialogueColor;

    private void OnGUI()
    {
        titleContent = new GUIContent("Edit dialogue line");
        GUILayout.Label("Line index");
        GUI.enabled = false;
        EditorGUILayout.TextField(lineName);
        GUI.enabled = true;
        
        
        selectedColor = EditorGUILayout.Popup("Change Color", selectedColor, colorOptions);//Fa scegliere il colore ma non lo cambia
        ChangeColor(selectedColor);//cambia il colore

        GUILayout.Label("Line Content");
        dialgogueLineContent = EditorGUILayout.TextArea(dialgogueLineContent, GUILayout.ExpandHeight(true));
        GUILayout.Space(25f);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("OK"))
        {
            confirm = true;
            Close();
        }
        if (GUILayout.Button("Cancel"))
        {
            Close();
        }

        GUILayout.EndHorizontal();
    }
    public void ChangeColor(int selectedColor)
    {
        switch (selectedColor)
        {
            case 0:
                dialogueColor = Color.white;
                break;
            case 1:
                dialogueColor = Color.red;
                break;
            case 2:
                dialogueColor = Color.blue;
                break;
            case 3:
                dialogueColor = Color.yellow;
                break;
            case 4:
                dialogueColor = Color.green;
                break;
            case 5:
                dialogueColor = Color.black;
                break;
            default:
                dialogueColor = Color.white;
                break;
        }

    }
}
