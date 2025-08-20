using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public int size = 10;
    private List<string> items = new List<string>();

    public bool AddItem(string item)
    {
        if (items.Count < size)
        {
            items.Add(item);
            Debug.Log("Добавлен предмет: " + item);
            return true;
        }
        
        Debug.Log("Инвентарь полон!");
        return false;
    }
}