using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public Transform player;
    public void ClickReaction(ItemData item)
    {
        player.position = item.goToPoint.position;
    }
    
}
