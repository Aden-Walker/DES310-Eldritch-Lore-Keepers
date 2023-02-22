using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialogue
{
    //Add public variables for use in editor
    [TextArea(minLines:3, maxLines:10)]
    public string[] sentences;
    
 
    public string name;
}
