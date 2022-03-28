using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class characterManager : MonoBehaviour
{
    [SerializeField] GameObject charName;
    [SerializeField] GameObject charClass;
    [SerializeField] GameObject charBG;
    [SerializeField] GameObject armorClass;
    [SerializeField] GameObject speed;
    [SerializeField] GameObject statINT;
    [SerializeField] GameObject statCHA;
    [SerializeField] GameObject statWIS;
    [SerializeField] GameObject statSTR;
    [SerializeField] GameObject statDEX;
    [SerializeField] GameObject statCON;
    [SerializeField] TMP_Text inventoryText;

    //need to calculate hit point text, calculate initiative, randomize values

    string characterName;
    string characterClass;
    string characterBG;
    string AC = "0";
    string hitPoints = "0";
    string charSpeed = "0";
    string intelligence = "0";
    string charisma = "0";
    string wisdom = "0";
    string strength = "0";
    string dexterity = "0";
    string consititution = "0";
    List<string> inventory = new List<string> { "Sword", "Torch", "Potion", "Staff", "Book", "Stone", "Amulet" };

    // Start is called before the first frame update
    void Start()
    {
        characterName = charName.GetComponent<TMP_InputField>().text;
        characterClass = charClass.GetComponent<TMP_Dropdown>().captionText.text;
        characterBG = charBG.GetComponent<TMP_InputField>().text;
        AC = armorClass.GetComponent<TMP_InputField>().text;
        charSpeed = speed.GetComponent<TMP_InputField>().text;
        intelligence = statINT.GetComponent<TMP_InputField>().text;
        charisma = statCHA.GetComponent<TMP_InputField>().text; 
        wisdom = statWIS.GetComponent<TMP_InputField>().text; 
        strength = statSTR.GetComponent<TMP_InputField>().text;
        dexterity = statDEX.GetComponent<TMP_InputField>().text;
        consititution = statCON.GetComponent<TMP_InputField>().text;
        inventoryText.text = string.Join(", ", inventory);
    }

    public void RandomizeCharacter()
    {

    }

    public void UpdateCharText()
    {
        characterName = charName.GetComponent<TMP_InputField>().text;
    }

    public void UpdateCharClass()
    {
        characterClass = charClass.GetComponent<TMP_Dropdown>().captionText.text;
        Debug.Log(characterClass);
    }

    public void UpdateCharBG()
    {
        characterBG = charBG.GetComponent<TMP_InputField>().text;
    }

    public void UpdateArmorClass()
    {
        AC = armorClass.GetComponent<TMP_InputField>().text;
    }

    public void UpdateSpeed()
    {
        charSpeed = speed.GetComponent<TMP_InputField>().text;
    }

    public void UpdateINT()
    {
        intelligence = statINT.GetComponent<TMP_InputField>().text;
    }

    public void UpdateCHA()
    {
        charisma = statCHA.GetComponent<TMP_InputField>().text;
    }

    public void UpdateWIS()
    {
        wisdom = statWIS.GetComponent<TMP_InputField>().text;
    }

    public void UpdateSTR()
    {
        strength = statSTR.GetComponent<TMP_InputField>().text;
    }

    public void UpdateCON()
    {
        consititution = statCON.GetComponent<TMP_InputField>().text;
    }
    
    public void UpdateDEX()
    {
        dexterity = statDEX.GetComponent<TMP_InputField>().text;
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
