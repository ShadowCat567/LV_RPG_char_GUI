using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class InventoryMethods : MonoBehaviour
{
    [SerializeField] TMP_Text inventoryText;
    List<string> inventory = new List<string> { "Sword", "Torch", "Potion", "Staff", "Book", "Stone", "Amulet" };

    // Start is called before the first frame update
    void Start()
    {
        inventoryText.text = string.Join(", ", inventory);
    }
    
    public void SortInventory()
    {
        IEnumerable<string> orderedInventory = from item in inventory
                                               orderby item ascending
                                               select item;
        inventoryText.text = string.Join(", ", orderedInventory);
    }

    public void UnsortInventory()
    {
        inventoryText.text = string.Join(", ", inventory);
    }
}
