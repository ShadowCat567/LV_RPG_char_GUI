using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class InventoryMethods : MonoBehaviour
{
    //variables for what goes in the inventory as well as connection to inventory object
    [SerializeField] TMP_Text inventoryText;
    List<string> inventory = new List<string> { "Sword", "Torch", "Potion", "Staff", "Book", "Stone", "Amulet" };

    // Start is called before the first frame update
    void Start()
    {
        //displays inventory list as a string
        inventoryText.text = string.Join(", ", inventory);
    }
    
    public void SortInventory()
    {
        //makes an IEnumberable which sorts the inventory string
        IEnumerable<string> orderedInventory = from item in inventory
                                               orderby item ascending
                                               select item;
        //displays sorted inventory
        inventoryText.text = string.Join(", ", orderedInventory);
    }

    public void UnsortInventory()
    {
        //displays unaltered inventory list
        inventoryText.text = string.Join(", ", inventory);
    }
}
