using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class DialogueManager : MonoBehaviour
{
    //Create variable to hold text box strings
    private Queue<string> _sentences;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    

    // Start is called before the first frame update
    void Start()
    {
        //create blank queue object
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //send text with name of object to name text public variable
        
        Debug.Log("Print text with name " + dialogue.name);
        nameText.text = dialogue.name;

        _sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }
        
        DisplaySentence();
    }

    public void DisplaySentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
        }
        else
        {
            string sentence  = _sentences.Dequeue();
            Debug.Log(sentence);
            dialogueText.text = sentence;
        }
    }

    void EndDialogue()
    {
        Debug.Log("Finished text");
    }

}
