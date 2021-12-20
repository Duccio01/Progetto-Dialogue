using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using TMPro;

public class DialogueLineEditor : EditorWindow
{
    public string dialogueIndex;
    public bool confirm;
    public int selectedColor;
    public string[] colorOptions = new string[] { "White", "Red", "Blue", "Yellow", "Green", "Black" };
    public float speedText;
    public Color dialogueColor;
    private float minTextSpeed = 0f;
    private float maxTextSpeed = 10f;
    public string selectedImage;

    private void OnGUI()
    {
        titleContent = new GUIContent("New Dialogue Line");

        EditorGUILayout.Space(5f);
        GUILayout.Label("New Line Name");
        EditorGUILayout.Space(2f);

        dialogueIndex = EditorGUILayout.TextField(dialogueIndex);
        EditorGUILayout.Space(5f);
        selectedColor = EditorGUILayout.Popup("Choose Color", selectedColor, colorOptions);//Fa scegliere il colore ma non lo cambia
        ChangeColor(selectedColor);//cambia il colore
        EditorGUILayout.Space(20f);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Text speed");
        speedText = EditorGUILayout.Slider(speedText, minTextSpeed, maxTextSpeed);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(25f);
        EditorGUILayout.BeginHorizontal();
        //Chose image for line

        GUILayout.Label("Character Image");
        //selectedImage=.....            //non ao come andare a scegliere l'immagine.

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical(GUILayout.ExpandHeight(true));
        EditorGUILayout.EndVertical();
        
        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("OK"))
        {
            confirm = true;
            Close();
        }
        if (GUILayout.Button("Cancel"))
        {
            Close();
        }
        EditorGUILayout.EndHorizontal();
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

    private void OnDestroy()
    {
        if (!confirm)
        {
            dialogueIndex = null;
        }
    }
}
