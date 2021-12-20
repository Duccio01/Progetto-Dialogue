using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class DialogueWindow : EditorWindow//Usare Esercizio dei linguaggi per aiutare
{
    [MenuItem("Dialogues/Create Dialogues")]
    private static void OpenWindow()
    {
        GetWindow<DialogueWindow>();
    }

    private Vector2 scrollPosition;
    private string[] dialogues;
    private string[] dialogueLabels;
    private int selectedDialogueIndex;

    private void OnGUI()
    {
        titleContent = new GUIContent("Dialogue Editor");

        if (GUILayout.Button("New Character Dialogue"))
        {
            NewDialogue();
        }
        GUILayout.Space(20f);
        GetAllDialogues();
        if (dialogues.Length == 0)
        {
            EditorGUILayout.HelpBox("No dialogues found", MessageType.Error);
            return;
        }
        selectedDialogueIndex = EditorGUILayout.Popup("Character Name:", selectedDialogueIndex, dialogueLabels);
        GUILayout.Label(dialogues[selectedDialogueIndex]);
       
        
        Dialogue dialog = AssetDatabase.LoadAssetAtPath<Dialogue>(dialogues[selectedDialogueIndex]);
        
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        string nameCharacter = dialogues[selectedDialogueIndex];
        for (int i = 0; i < dialog.dialogues.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();


            if (GUILayout.Button("+", EditorStyles.toolbarButton, GUILayout.Width(25f)))
            {
                EditorDialogueTextWindow editWindow = GetWindow<EditorDialogueTextWindow>();
                editWindow.lineName = dialog.dialogues[i].nameText;
                editWindow.dialogueColor = dialog.dialogues[i].textColor;
                editWindow.dialgogueLineContent = dialog.dialogues[i].dialogueLineText;
                editWindow.ShowModalUtility();

                if (editWindow.confirm)
                {
                    dialog.dialogues[i].dialogueLineText = editWindow.dialgogueLineContent;
                    dialog.dialogues[i].textColor = editWindow.dialogueColor;
                    EditorUtility.SetDirty(dialog);
                }
            }

            if (GUILayout.Button("-", EditorStyles.toolbarButton, GUILayout.Width(25f)))
            {
                if (EditorUtility.DisplayDialog("Confirm", $"Do you really want to remove the string {dialog.dialogues[i].nameText}?", "Yes", "No"))
                {
                    RemoveLine(dialog.dialogues[i].nameText,nameCharacter);
                    break;

                }

            }

            EditorGUILayout.LabelField(dialog.dialogues[i].nameText, dialog.dialogues[i].dialogueLineText);

            EditorGUILayout.EndHorizontal();
            //GUILayout.Label(language.strings[i].index);
        }
        
          EditorGUILayout.EndScrollView();
         

        if (GUILayout.Button("New Dialogue Line"))
        {
            DialogueLineEditor dialogueEditor = EditorWindow.GetWindow<DialogueLineEditor>();
            dialogueEditor.ShowModalUtility();
            if (!string.IsNullOrWhiteSpace(dialogueEditor.dialogueIndex))
            {
                string newDialogueIndex = dialogueEditor.dialogueIndex.ToUpper();
                Color colorText = dialogueEditor.dialogueColor;
                float dialogueSpeed = dialogueEditor.speedText;
                
                if (dialog.dialogues.Exists(s => s.nameText == newDialogueIndex && s.characterName==nameCharacter))
                {
                    EditorUtility.DisplayDialog("Error", $"Dialogue {newDialogueIndex} already exist", "Ok");
                }
                else
                {
                    AddLine(newDialogueIndex, nameCharacter,colorText, dialogueSpeed/* da aggiungere qui parte immagine*/);
                }


            }
        }
    }

    private void RemoveLine(string textName, string character)
    {
        foreach(string dialoguePath in dialogues)
        {
            Dialogue dialogue = AssetDatabase.LoadAssetAtPath<Dialogue>(dialoguePath);
            dialogue.dialogues.RemoveAll(s => s.nameText == textName && s.characterName == character);
        }
    }

    private void GetAllDialogues()
    {
        dialogues = AssetDatabase.FindAssets("t: Dialogue");
        dialogueLabels = new string[dialogues.Length];
        for (int i = 0; i < dialogues.Length; i++)
        {
            dialogues[i] = AssetDatabase.GUIDToAssetPath(dialogues[i]);
            dialogueLabels[i] = Path.GetFileName(dialogues[i]);
        }
    }

    private void NewDialogue()
    {
        string path = EditorUtility.SaveFilePanelInProject("New Dialogue", "dialogue", "asset","Dialoghi", "new dialogue location");
        if (!string.IsNullOrWhiteSpace(path))
        {
            Dialogue newDialogue = ScriptableObject.CreateInstance<Dialogue>();
           // Dialogue currentDialogue = AssetDatabase.LoadAssetAtPath<Dialogue>();
            AssetDatabase.CreateAsset(newDialogue, path);

            //newDialogue.dialogues.AddRange(currentDialogue.dialogues);
            EditorUtility.SetDirty(newDialogue);
        }
    }


    private void AddLine(string newDialogueIndex, string name,Color colorText,float dialogueSpeed /* da aggiungere qui parte immagine*/)//Corrisponde a AddString()
    {
        //foreach(string dialoguePath in dialogues)
        //{
            Dialogue dialogue = AssetDatabase.LoadAssetAtPath<Dialogue>(dialogues[selectedDialogueIndex]);
            Dialogue.DialogueBox newDialogue = new Dialogue.DialogueBox()
            {   nameText = newDialogueIndex, 
                characterName = name, textColor = colorText,
                textSpeed=dialogueSpeed ,
                dialogueLineText = ""
                /*, da aggiungere qui parte immagine*/
            };

            dialogue.dialogues.Add(newDialogue);
            EditorUtility.SetDirty(dialogue);
//        }
    }
}
