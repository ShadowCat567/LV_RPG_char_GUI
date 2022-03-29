using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class characterManager : MonoBehaviour
{
    //variables related to the UI elements on screen
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
    [SerializeField] TMP_Text MaxhitPointText;
    [SerializeField] TMP_Text CurhitPointText;
    [SerializeField] TMP_Text initativeText;

    //variables for the three different base hp values
    int martialHP = 10;
    int hybridHP = 8;
    int casterHP = 6;

    //variables to store the text from the UI elements
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
    string initiative = "+0";
    string[] backgroundArr = { "Acolyte", "Charlatan", "Gladiator", "Criminal", "Folk Hero", "Hermit" };

    // Start is called before the first frame update
    void Start()
    {
        //stores text from UI elements in string variables
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
        MaxhitPointText.text = "Maximum Hit Points: " + hitPoints;
        CurhitPointText.text = "Current Hit Points: " + hitPoints;
        initativeText.text = initiative;
    }

    public void RandomizeCharacter()
    {
        //generates random values and stores them in their corresponding variable
        //attribute stats have a randomly generated limit of 1-20 since that's the limit in Dungeons and Dragons
        strength = Random.Range(1, 20).ToString();
        dexterity = Random.Range(1, 20).ToString();
        consititution = Random.Range(1, 20).ToString();
        intelligence = Random.Range(1, 20).ToString();
        charisma = Random.Range(1, 20).ToString();
        wisdom = Random.Range(1, 20).ToString();
        //armor class has a limit of 10-20 since that's where most DnD armor classes are
        AC = Random.Range(10, 20).ToString();
        //speed is not randomly generated, most DnD characters have a speed of 30ft
        charSpeed = "30";
        //selects a random index value from the Backgrounds array
        int randomBG = Random.Range(0, 5);
        //selects a random index value from the options list within the character class drop down 
        int randomClass = Random.Range(1, 6);
        characterBG = backgroundArr[randomBG];
        characterClass = charClass.GetComponent<TMP_Dropdown>().options[randomClass].text;

        //displays the randomly generated values in their correct place
        charBG.GetComponent<TMP_InputField>().text = characterBG;
        charClass.GetComponent<TMP_Dropdown>().captionText.text = characterClass;
        armorClass.GetComponent<TMP_InputField>().text = AC;
        speed.GetComponent<TMP_InputField>().text = charSpeed;
        statINT.GetComponent<TMP_InputField>().text = intelligence;
        statCHA.GetComponent<TMP_InputField>().text = charisma;
        statWIS.GetComponent<TMP_InputField>().text = wisdom;
        statSTR.GetComponent<TMP_InputField>().text = strength;
        statDEX.GetComponent<TMP_InputField>().text = dexterity;
        statCON.GetComponent<TMP_InputField>().text = consititution;

        //calculates the Randomly generated character's HP and initiative
        CalculateHitPoints();
        calculateInitiative();
    }

    public void UpdateCharText()
    {
        //updates the character's name to the value inputted to the Input field
        characterName = charName.GetComponent<TMP_InputField>().text;
    }

    public void UpdateCharClass()
    {
        //updates the character's class to the value selected from the Dropdown and calculate HP based on class
        characterClass = charClass.GetComponent<TMP_Dropdown>().captionText.text;
        //makes sure exepection is not thrown if the player does not input anything in Character class or consititution
        if (statCON.GetComponent<TMP_InputField>().text != "" && charClass.GetComponent<TMP_Dropdown>().captionText.text != "Character Class")
        {
            CalculateHitPoints();
        }
    }

    public void UpdateCharBG()
    {
        //updates the character's background to the value inputted to the Input field
        characterBG = charBG.GetComponent<TMP_InputField>().text;
    }

    public void UpdateArmorClass()
    {
        //updates the character's Armor class to the value inputted to the Input field
        AC = armorClass.GetComponent<TMP_InputField>().text;
    }

    public void UpdateSpeed()
    {
        //updates the character's speed to the value inputted to the Input field
        charSpeed = speed.GetComponent<TMP_InputField>().text;
    }

    public void UpdateINT()
    {
        //updates intelligence stat to the value inputted to the Input field
        intelligence = statINT.GetComponent<TMP_InputField>().text;
    }

    public void UpdateCHA()
    {
        //updates charisma stat to the value inputted to the Input field
        charisma = statCHA.GetComponent<TMP_InputField>().text;
    }

    public void UpdateWIS()
    {
        //updates wisdom stat to the value inputted to the Input field
        wisdom = statWIS.GetComponent<TMP_InputField>().text;
    }

    public void UpdateSTR()
    {
        //updates strength stat to the value inputted to the Input field
        strength = statSTR.GetComponent<TMP_InputField>().text;
    }

    public void UpdateCON()
    {
        //updates constitution stat to the value inputted to the Input field and updates the character's HP based on CON
        consititution = statCON.GetComponent<TMP_InputField>().text;
        //makes sure excepection is not thrown if the player does not input anything in Character class or consititution
        if (statCON.GetComponent<TMP_InputField>().text != "" && charClass.GetComponent<TMP_Dropdown>().captionText.text != "Character Class")
        {
            CalculateHitPoints();
        }
    }
    
    public void UpdateDEX()
    {
        //updates dexterity stat to the value inputted to the Input field and updates the character's initative based on DEX
        dexterity = statDEX.GetComponent<TMP_InputField>().text;
        //makes sure execption is not thrown if player does not input anything in dexterity
        if (statDEX.GetComponent<TMP_InputField>().text != "")
        {
            calculateInitiative();
        }
    }

    void CalculateHitPoints()
    {
        //calculates the constitution modifier based on constitution's value, then uses the character class and consitiution modifier to calculate HP value
        int ConMod = ConvertToModifier(int.Parse(consititution));

        if (characterClass == "Fighter" || characterClass == "Paladin" || characterClass == "Ranger")
        {
            hitPoints = (martialHP + ConMod).ToString();
        }

        else if(characterClass == "Bard" || characterClass == "Rogue")
        {
            hitPoints = (hybridHP + ConMod).ToString();
        }

        else if(characterClass == "Sorcerer" || characterClass == "Wizard")
        {
            hitPoints = (casterHP + ConMod).ToString();
        }

        else
        {
            hitPoints = "0";
        }

       //updates text to match HP value calculated
        MaxhitPointText.text = "Maximum Hit Points: " + hitPoints;
        CurhitPointText.text = "Current Hit Points: " + hitPoints;
    }

    void calculateInitiative()
    {
        //calculates dexterity modifier based on dexterity stat and updates intitative text to match the value
        int dexMod = ConvertToModifier(int.Parse(dexterity));

        if (dexMod < 0)
        {
            initativeText.text = dexMod.ToString();
        }
        else
        {
            initativeText.text = "+" + dexMod.ToString();
        }
    }

    int ConvertToModifier(int stat)
    {
        //converts the raw stat value to a modifier based on the modifiers in Dungeons and Dragons
        //takes the stat value, returns the modifier
        int mod = 0;

        if (stat == 1)
            mod = -5;
        else if (stat == 2 || stat == 3)
            mod = -4;
        else if (stat == 4 || stat == 5)
            mod = -3;
        else if (stat == 6 || stat == 7)
            mod = -2;
        else if (stat == 8 || stat == 9)
            mod = -1;
        else if (stat == 10 || stat == 11)
            mod = 0;
        else if (stat == 12 || stat == 13)
            mod = 1;
        else if (stat == 14 || stat == 15)
            mod = 2;
        else if (stat == 16 || stat == 17)
            mod = 3;
        else if (stat == 18 || stat == 19)
            mod = 4;
        else if (stat == 20)
            mod = 5;
        else
            mod = 0;

        return mod;
    }
}
