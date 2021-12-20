using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeTextMesh : MonoBehaviour
{

    public string nameText;
    public string characterName;
    public string lastNameText;
    public string lastCharacterName;
    public Dialogue.DialogueBox newColor;
    private void Update()
    {
        if(nameText!=lastNameText || characterName!=lastCharacterName)
        {
            lastNameText = nameText;
            lastCharacterName = characterName;
            
            TextMeshProUGUI textMesh = GetComponent<TextMeshProUGUI>();
            textMesh.color = newColor.textColor;
        }
    }

}
