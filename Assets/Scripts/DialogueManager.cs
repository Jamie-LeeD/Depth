using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI dialogueBox;
    [SerializeField]
    List<Dialogue> dialogueList = new List<Dialogue>();

    int currentDialogue;
    int textIndex;
    float readTime;

    void Awake()
    {
        ChangeDialogue(1);
    }

    void Update()
    {
        readTime += Time.deltaTime;
        if (textIndex >= dialogueList[currentDialogue].text.Length) return;
        if (readTime < 1f / dialogueList[currentDialogue].charactersPerSecond) return;
        int characters = (int)(readTime * dialogueList[currentDialogue].charactersPerSecond);
        readTime = 0f;
        for (int i = 0; i < characters; i++)
        {
            dialogueBox.text += dialogueList[currentDialogue].text[textIndex];
            textIndex++;
            if (textIndex >= dialogueList[currentDialogue].text.Length) return;
        }
    }
    
    public void ChangeDialogue(int dialogueNumber)
    {
        dialogueBox.text = "";
        currentDialogue = dialogueNumber;
        textIndex = 0;
        readTime = 0f;
        dialogueBox.fontSize = dialogueList[currentDialogue].fontSize;
        if (dialogueList[currentDialogue].type == Dialogue.Type.Speaking)
        {
            dialogueBox.fontStyle = FontStyles.Normal;
        }
        else if (dialogueList[currentDialogue].type == Dialogue.Type.Action)
        {
            dialogueBox.fontStyle = FontStyles.Italic;
        }
    }
}
