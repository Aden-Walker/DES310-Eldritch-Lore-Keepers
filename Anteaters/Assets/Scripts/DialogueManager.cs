using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //Create variable to hold text box strings
    private Queue<string> _sentences;

    public Text nameText;
    public Text dialogueText;
    

    // Start is called before the first frame update
    void Start()
    {
        //create blank queue object
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //send text with name of object to name text public variable
        
        //Debug.Log("Print text with name " + dialogue.Name);
        nameText.text = dialogue.Name;
        
        _sentences.Clear();

        foreach (string sentence in dialogue.Sentences)
        {
            _sentences.Enqueue(sentence);
        }
        
    }

    public void DisplaySentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
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
