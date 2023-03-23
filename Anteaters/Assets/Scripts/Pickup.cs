using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Animator animator;
    public Inventory inventory;


    public void pickup()
    {
        if (animator.GetBool("BranchFallen"))
        {
            inventory.SetBranch(true);
        }
    }
}
