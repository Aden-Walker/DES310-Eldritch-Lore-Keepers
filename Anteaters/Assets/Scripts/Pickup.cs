using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Animator animator;
    public Inventory inventory;


    void pickup()
    {
        if (animator.GetBool("BranchFallen"))
        {
            inventory.Branch = true;
        }
    }
}
