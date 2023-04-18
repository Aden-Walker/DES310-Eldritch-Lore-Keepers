
using UnityEngine;

public class BranchCheck : MonoBehaviour
{
    public Inventory inventory;
    public GameObject path;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player" && inventory.GetBranch())
        {
            path.SetActive(true);
        }
    }
}
