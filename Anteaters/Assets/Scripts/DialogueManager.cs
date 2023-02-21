using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    //Create variable to hold text box strings
    private Queue<string> _sentences;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Print text with name " + dialogue.Name);
        
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
        }
    }

    void EndDialogue()
    {
        Debug.Log("Finished text");
    }

}
