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

    private bool finishedSentence;
    private string currentString;

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

        //clear dialogue from previous text box
        _sentences.Clear();

        //add sentences to queue
        foreach (string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }

        //move the text box down
        animator.SetBool("IsOpen", true);
        DisplaySentence();
    }

    public void DisplaySentence()
    {   
        //check if there is a sentence to display
        if (_sentences.Count == 0)
        {
            //close text box
            EndDialogue();
        }
        else 
        {   
            //load next sentence in queue
            string sentence = _sentences.Dequeue();
            Debug.Log(sentence);
            //type sentence with typewriter effect
            finishedSentence = false;
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
            
             yield return new WaitForSeconds(0.05f);

        }
        finishedSentence = true;
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
