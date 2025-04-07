using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    int nextScene;
    [SerializeField]
    Button nextDialogueButton;
    [SerializeField]
    Image backgroundImage;
    [SerializeField]
    Image speakerImage;
    [SerializeField]
    TextMeshProUGUI speakerName;
    [SerializeField]
    TextMeshProUGUI dialogueTags;
    [SerializeField]
    TextMeshProUGUI dialogueText;
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
            nextDialogueButton.gameObject.SetActive(true);
            return;
        }
        nextDialogueButton.gameObject.SetActive(false);
        if (readTime < 1f / dialogueList[currentDialogue].charactersPerSecond) return;
        int characters = (int)(readTime * dialogueList[currentDialogue].charactersPerSecond);
        readTime = 0f;
        for (int i = 0; i < characters; i++)
        {
            dialogueText.text += dialogueList[currentDialogue].text[textIndex];
            textIndex++;
            if (textIndex >= dialogueList[currentDialogue].text.Length) return;
        }
    }
    
    void NextDialogue()
    {
        if (currentDialogue == dialogueList.Count - 1)
        {
            NextScene();
            return;
        }
        dialogueText.text = "";
        dialogueTags.text = "(";
        currentDialogue++;
        textIndex = 0;
        readTime = 0f;
        dialogueText.fontSize = dialogueList[currentDialogue].fontSize;
        if (dialogueList[currentDialogue].type == Dialogue.Type.Speaking)
        {
            dialogueText.fontStyle = FontStyles.Normal;
        }
        else if (dialogueList[currentDialogue].type == Dialogue.Type.Action)
        {
            dialogueText.fontStyle = FontStyles.Italic;
        }
        backgroundImage.sprite = dialogueList[currentDialogue].backgroundImage;
        speakerImage.sprite = dialogueList[currentDialogue].speakerImage;
        speakerName.text = dialogueList[currentDialogue].speaker;
        Array.ForEach<string>(dialogueList[currentDialogue].tags.ToArray(), t => dialogueTags.text += $"{t}, ");
        if (dialogueTags.text != "(")
        {
            dialogueTags.text = dialogueTags.text.Substring(0, dialogueTags.text.Length - 2);
            dialogueTags.text += ")";
        }
        else
        {
            dialogueTags.text = "";
        }
    }

    void NextScene()
    {
        SceneManager.LoadSceneAsync(nextScene);
    }
}
