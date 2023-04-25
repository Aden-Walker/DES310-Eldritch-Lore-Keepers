
using UnityEngine;

public class BranchCheck : MonoBehaviour
{
    public Inventory inventory;
    public GameObject path;
    public GameObject branch;
    private void OnTriggerEnter2D(Collider2D col)
    {
        //change path layer to active and display branch if player collides and has branch
        if (col.name == "Player" && inventory.GetBranch())
        {
            path.layer = 0;
            branch.SetActive(true);
        }
    }
}
