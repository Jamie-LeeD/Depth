using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI dialogueBox;
    [SerializeField]
    List<Dialogue> dialogueList = new List<Dialogue>();

    public bool dialogueEnabled;
    public int currentDialogue;
    int textIndex;
    float readTime;

    void Update()
    {
        if (!dialogueEnabled) return;
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
}
