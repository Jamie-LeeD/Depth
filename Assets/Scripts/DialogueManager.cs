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

    void Update()
    {
        readTime += Time.deltaTime;
        if (textIndex >= dialogueList[currentDialogue].text.Length) return;
        if (readTime < dialogueList[currentDialogue].charactersPerSecond) return;
        int characters = (int)(readTime / dialogueList[currentDialogue].charactersPerSecond);
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
    }
}
