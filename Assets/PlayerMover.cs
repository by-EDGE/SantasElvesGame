using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float stopDistance = 1f;

    private Pickup currentTarget;
    private Inventory inventory;

    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        if (currentTarget != null)
        {
            Vector3 targetPos = currentTarget.transform.position;
            float distance = Vector3.Distance(transform.position, targetPos);

            if (distance > stopDistance)
            {
                Vector3 dir = (targetPos - transform.position).normalized;
                transform.position += dir * moveSpeed * Time.deltaTime;
            }
            else
            {
                currentTarget.TryPickup(transform, inventory);
                currentTarget = null;
            }
        }
    }

    public void SetTarget(Pickup target)
    {
        currentTarget = target;
    }
}