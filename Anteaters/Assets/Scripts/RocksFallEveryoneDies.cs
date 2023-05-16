using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksFallEveryoneDies : MonoBehaviour
{
    // Start is called before the first frame update


    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void triggerCollapse()
    {
        animator.SetBool("CollapseTriggered", true);

    }
}
