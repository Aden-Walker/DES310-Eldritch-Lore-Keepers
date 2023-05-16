using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene5CutsceneHandler : MonoBehaviour
{


    public GameObject cutscene;

    Animator animator;

    public bool cutsceneFinished;
    private bool moveOn;

    // Start is called before the first frame update
    void Start()
    {
        animator = cutscene.GetComponent<Animator>();
        moveOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("DogEndState") || animator.GetCurrentAnimatorStateInfo(0).IsName("TractorEndState"))
        {
            if(moveOn)
            {
                SceneManager.LoadScene(5);
            }
        }
    }

    public Animator GetAnimator()
    {
        return animator;
    }

    public void Continue()
    {
        moveOn = true;
    }
}
