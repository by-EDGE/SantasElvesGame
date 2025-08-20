using System;
using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

[RequireComponent(typeof(Inventory))]
public class Pickup : MonoBehaviour
{
    public string itemName;
    public float pickupDistance = 2f;
    public float stopDistance = 1f;
    public float pickupDelay = 1.5f;

    private bool isBeingPickedUp = false;

    public void Interact()
    {
        if (isBeingPickedUp) return;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerMover mover = player.GetComponent<PlayerMover>();
            if (mover != null)
            {
                mover.SetTarget(this);
                Debug.Log("== PICKUP == Цель установлена: " + name);
            }
        }
    }

    public async void TryPickup(Transform playerTransform, Inventory inventory)
    {
        if (isBeingPickedUp) return;

        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance > pickupDistance) return;

        if (inventory.AddItem(itemName))
        {
            Debug.Log("== PICKUP == Подобрано: " + itemName);
            // StartCoroutine(HandlePickup());
            await HandlePickup();
        }
        else
        {
            Debug.Log("== PICKUP == Инвентарь полон");
        }
    }

    private async Task HandlePickup(){
        isBeingPickedUp = true;
        await UniTask.WaitForSeconds(pickupDelay);
        Destroy(gameObject);
    }


// private IEnumerator HandlePickup()
//     {
//         isBeingPickedUp = true;
//
//         //if (pickupAnimator != null)
//         //{
//           //  pickupAnimator.SetTrigger("Pickup"); // анимация, если есть
//         //}
//
//         yield return new WaitForSeconds(pickupDelay);
//
//         Destroy(gameObject);
//     }
// }
}