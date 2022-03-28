using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField] TMP_Text MaxhitPointText;
    [SerializeField] TMP_Text CurhitPointText;
    [SerializeField] TMP_Text initativeText;

    //need to randomize values

    int martialHP = 10;
    int hybridHP = 8;
    int casterHP = 6;

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
        strength = Random.Range(1, 20).ToString();
        dexterity = Random.Range(1, 20).ToString();
        consititution = Random.Range(1, 20).ToString();
        intelligence = Random.Range(1, 20).ToString();
        charisma = Random.Range(1, 20).ToString();
        wisdom = Random.Range(1, 20).ToString();
        AC = Random.Range(10, 20).ToString();
        charSpeed = "30";
        int randomBG = Random.Range(0, 5);
        int randomClass = Random.Range(1, 6);
        characterBG = backgroundArr[randomBG];
        characterClass = charClass.GetComponent<TMP_Dropdown>().options[randomClass].text;

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

        CalculateHitPoints();
        calculateInitiative();
    }

    public void UpdateCharText()
    {
        characterName = charName.GetComponent<TMP_InputField>().text;
    }

    public void UpdateCharClass()
    {
        characterClass = charClass.GetComponent<TMP_Dropdown>().captionText.text;
        CalculateHitPoints();
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
        CalculateHitPoints();
    }
    
    public void UpdateDEX()
    {
        dexterity = statDEX.GetComponent<TMP_InputField>().text;
        calculateInitiative();
    }

    void CalculateHitPoints()
    {
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
       
        MaxhitPointText.text = "Maximum Hit Points: " + hitPoints;
        CurhitPointText.text = "Current Hit Points: " + hitPoints;
    }

    void calculateInitiative()
    {
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
