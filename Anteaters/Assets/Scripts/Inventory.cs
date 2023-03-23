using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool _branch = false;

    public void SetBranch(bool set)
    {
        if (set == true)
        {
            Debug.Log("Branch picked up");
        }
        _branch = set;
    }

    public bool GetBranch()
    {
        return _branch;
    }
    
    
}
