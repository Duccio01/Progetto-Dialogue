using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Dialogue.asset", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
   [Serializable]public class DialogueBox
    {
        public string nameText;//Nome del testo
        public string characterName;//Nome di chi parla
        public string dialogueLineText;
        // public .... imageCharacter//Serve il ritratto del personaggio ma non so il tipo
        public Color textColor;
        public float textSpeed;
    }

    public List<DialogueBox> dialogues = new List<DialogueBox>();

   
}
