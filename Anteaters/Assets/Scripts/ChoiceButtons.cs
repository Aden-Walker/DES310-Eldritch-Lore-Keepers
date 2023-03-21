using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceButtons : MonoBehaviour
{

    public int buttonId;
    public GameObject transitionArrow;

    Color mouseOverColour = Color.red;
    Color originalColour;

    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        originalColour = renderer.material.color;
    }


    private void OnMouseOver()
    {
        renderer.material.color = mouseOverColour;
        Debug.Log("Mouse over button" + buttonId);
    }

    private void OnMouseExit()
    {
        renderer.material.color = originalColour;
        Debug.Log("Mouse exited button" + buttonId);
    }

    private void OnMouseDown()
    {
        switch (buttonId)
        {
            case 0:
                transitionArrow.GetComponent<Transition>().handleTransition(2);
                break;
            case 1:
                transitionArrow.GetComponent<Transition>().handleTransition(2);
                break;
        }
    }
}
