using UnityEngine;

public class ClickTest : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Подарок кликнут: " + gameObject.name);
    }
}