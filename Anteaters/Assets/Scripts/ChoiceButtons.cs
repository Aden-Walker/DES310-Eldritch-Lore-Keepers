using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChoiceButtons : MonoBehaviour
{

    public int buttonId;
    public GameObject transitionArrow;

    Color mouseOverColour = Color.green;
    Color originalColour;

    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        originalColour = Color.grey;

        renderer.material.color = originalColour;
    }


    private void OnMouseOver()
    {
        //changes colour when the button is hovered over
        renderer.material.color = mouseOverColour;
     
    }

    private void OnMouseExit()
    {
        //resets colour when the button is no longer hovered over
        renderer.material.color = originalColour;
       
    }

    private void OnMouseDown()
    {
        // switch statement using the button id assigned in editor. Very dirty as it relies on every scene button having a different id
        switch (buttonId)
        {
            case 0:
                transitionArrow.GetComponent<Transition>().SetAnimatorParams(true, false);
                break;
            case 1:
                transitionArrow.GetComponent<Transition>().SetAnimatorParams(true, true);
                break;
            case 2:
                transitionArrow.GetComponent<Transition>().handleTransition(4);
                break;
            case 3:
                transitionArrow.GetComponent<Transition>().handleTransition(4);
                break;
            case 4:
                GetComponent<Scene5CutsceneHandler>().GetAnimator().SetTrigger("DogChoice");
                transitionArrow.GetComponent<Transition>().GetRidOfEm();
                break;
            case 5:
                GetComponent<Scene5CutsceneHandler>().GetAnimator().SetTrigger("TractorChoice");
                transitionArrow.GetComponent<Transition>().GetRidOfEm();
                break;
            
        }
    }
}
