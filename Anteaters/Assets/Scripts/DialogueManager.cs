using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class DialogueManager : MonoBehaviour
{
    //Create variable to hold text box strings
    private Queue<string> _sentences;
    
    
    //public editor variables and links to ui
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;

    public Pickup pickup;
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
        StartCoroutine(TypeSentence(currentText));
    }

    public void DisplaySentence()
    {
        //check if the coroutine has finished adding text to the text box
        if (currentText == dialogueText.text)
        {
            //check if there is a sentence to display
            if (_sentences.Count == 0)
            {
                if (nameText.text == "Tree")
                {
                    pickup.animator.SetBool("BranchFallen", true);
                }
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
            Debug.Log("Stopping coroutine and displaying full text");
            StopAllCoroutines();
            dialogueText.text = currentText;
        }
    }

    private IEnumerator TypeSentence(string sentence)
    {
        // set initial text to be blank
        dialogueText.text = "";
        
        Debug.Log("coroutine sentence: " + sentence);

        // start a loop that runs frame independent
        foreach (char letter in sentence.ToCharArray())
        {
            //add next letter to text box text
            dialogueText.text += letter;
            Debug.Log(dialogueText.text);

            //wait for time delay before doing next iteration
            yield return new WaitForSeconds(timeDelay);
            Debug.Log("sasdfahasdiofuhsdaf");
        }

        yield break;

    }

    void EndDialogue()
    {
        //close text box
        animator.SetBool("IsOpen", false);
    }
}
