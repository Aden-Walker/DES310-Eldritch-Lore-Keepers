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
    public float timeDelay;

    private string currentText = "";
    
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
        LoadNext();
    }

    public void LoadNext()
    {
        //load next sentence in queue
        currentText = _sentences.Dequeue();
        Debug.Log(currentText);
        //type sentence with typewriter effect
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentText, timeDelay));
    }

    public void DisplaySentence()
    {
        //check if the coroutine has finished adding text to the text box
        if (currentText == dialogueText.text)
        {
            //check if there is a sentence to display
            if (_sentences.Count == 0)
            {
                //close text box
                EndDialogue();
            }
            else
            {
                LoadNext();
            }
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = currentText;
        }
    }

    private IEnumerator TypeSentence(string sentence, float timeDelay)
    {
        // set initial text to be blank
        dialogueText.text = "";
        
        // start a loop that runs frame independent
        foreach (char letter in sentence.ToCharArray())
        {
            //add next letter to text box
            dialogueText.text += letter;

            //wait for time delay in seconds
            yield return new WaitForSeconds(timeDelay);
        }
        
    }

    void EndDialogue()
    {
        //close text box
        animator.SetBool("IsOpen", false);
    }
}
