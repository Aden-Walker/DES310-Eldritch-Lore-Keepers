using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class DialogueManager : MonoBehaviour
{
    //Create variable to hold text box strings
    private Queue<string> _sentences;
    
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        //create blank queue object
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //send text with name of object to name text public variable
        
        
        nameText.text = dialogue.name;

        _sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }
        animator.SetBool("IsOpen", true);
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
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return 0.3;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        
    }
}
