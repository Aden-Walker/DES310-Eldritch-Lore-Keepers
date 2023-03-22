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
            Debug.Log("Branch picked up");
            inventory.setBranch(true);
        }
    }
}
