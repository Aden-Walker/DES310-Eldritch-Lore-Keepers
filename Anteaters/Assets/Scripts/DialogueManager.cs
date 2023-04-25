using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    private void LoadNext()
    {
        //load next sentence in queue
        currentText = _sentences.Dequeue();
        
        //type sentence with typewriter effect
        StopAllCoroutines();            //Maybe redundant
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
               
                //close text box
                EndDialogue();
            }
            else
            {
                //check if the last text box of the tree text box is displayed
                if (_sentences.Count == 1 && nameText.text == "Tree")
                {
                    pickup.animator.SetBool("BranchFallen", true);
                    var branchButton = GameObject.Find("BranchPickupButton");
                    RectTransform buttonPos = branchButton.GetComponent<RectTransform>();
                    buttonPos.position.Set(920, -273, -9720);
                }


                // load next sentence
                LoadNext();
            }
        }
        else
        {
            //stop typewriter effect and set text to be full
            StopAllCoroutines();
            dialogueText.text = currentText;
        }
    }

    private IEnumerator TypeSentence(string sentence)
    {
        // set initial text to be blank
        dialogueText.text = "";
        
       

        // start a loop that runs frame independent
        foreach (char letter in sentence.ToCharArray())
        {
            //add next letter to text box text
            dialogueText.text += letter;

            //wait for time delay before doing next iteration
            yield return new WaitForSeconds(timeDelay);
           
        }

        yield break;

    }

    void EndDialogue()
    {
        //close text box
        animator.SetBool("IsOpen", false);
    }
}
