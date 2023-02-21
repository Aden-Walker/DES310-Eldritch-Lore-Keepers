using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialogue
{
    //Add public variables for use in editor
    
    public string[] Sentences;
    
    [TextArea(minLines:3, maxLines:10)]
    public string Name;
}
