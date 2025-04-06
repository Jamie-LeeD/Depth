using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    Button nextDialogueButton;
    [SerializeField]
    Image backgroundImage;
    [SerializeField]
    Image speakerImage;
    [SerializeField]
    TextMeshProUGUI speakerBox;
    [SerializeField]
    TextMeshProUGUI tagBox;
    [SerializeField]
    TextMeshProUGUI dialogueBox;
    [SerializeField]
    List<Dialogue> dialogueList = new List<Dialogue>();

    int currentDialogue = -1;
    int textIndex;
    float readTime;

    void Awake()
    {
        NextDialogue();
        nextDialogueButton.onClick.AddListener(NextDialogue);
    }

    void Update()
    {
        readTime += Time.deltaTime;
        if (textIndex >= dialogueList[currentDialogue].text.Length)
        {
            nextDialogueButton.enabled = true;
            return;
        }
        nextDialogueButton.enabled = false;
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
    
    public void NextDialogue()
    {
        dialogueBox.text = "";
        tagBox.text = "(";
        currentDialogue++;
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
        backgroundImage.sprite = dialogueList[currentDialogue].backgroundImage?.sprite;
        speakerImage.sprite = dialogueList[currentDialogue].speakerImage?.sprite;
        speakerBox.text = dialogueList[currentDialogue].speaker;
        Array.ForEach<string>(dialogueList[currentDialogue].tags.ToArray(), t => tagBox.text += $"{t}, ");
        if (tagBox.text != "(")
        {
            tagBox.text = tagBox.text.Substring(0, tagBox.text.Length - 2);
            tagBox.text += ")";
        }
        else
        {
            tagBox.text = "";
        }
    }
}
