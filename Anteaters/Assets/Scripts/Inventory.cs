using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool Branch = false;

    public void setBranch(bool set)
    {
        Branch = set;
    }

    public bool getBranch()
    {
        return Branch;
    }
    
    
}
