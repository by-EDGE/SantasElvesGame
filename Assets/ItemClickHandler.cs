using UnityEngine;

public class ItemClickHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ЛКМ
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Pickup pickup = hit.collider.GetComponent<Pickup>();
                if (pickup != null)
                {
                    pickup.Interact(); // вместо TryPickup
                }
            }
        }
    }
}