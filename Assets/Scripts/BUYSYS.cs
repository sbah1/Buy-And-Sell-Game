using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Included to allow the script to interact with UI elements

public class BUYSYS : MonoBehaviour
{
    public static BUYSYS buy; //Used to initialize script in specific screen/scenario
    [SerializeField] public int cash; //The cash variable itself, duh.
    public Text SmaAmt;
    public Text MedAmt;
    public Text LarAmt;
    public Text SpeAmt;

    public Text cashText; //Used to print the cash amount to the screen
    public Text inventory; //Text to display to
    public Text upgTxt; //Used to display upgrade button text
    public Text upgBtn; //Used to update the upgrate text on the button

    //initialization
    void Start()
    {
        buy = this; //Initialize the script in the screen it's being used on
    }

    void Update()
    {
        UpdateUI(); //Print cash to screen
    }

    public void AddMoney(int amount)
    {
        cash += amount; //Add cash to the amount
        UpdateUI();
    }

    public void RemMoney(int amount)
    {
        cash -= amount; //Remove cash from the current amount
        UpdateUI();
    }

    public bool ReqMoney(int amount)
    {
        if (cash >= amount) //If the amount available is more than/equal to the purchase cost
        {
            return true; //You can buy it
        }
        else //Otherwise
        {
            return false; //Nah bruh, you can't buy this.
        }
    }

    public bool ReqSpace(int crates)
    {
        if (INVENT.inventoryLevel >= INVENT.maxInventory)
        {
            Debug.Log("Inventory Full!");
            return false;
        }
        else
        {
            if (crates > (INVENT.maxInventory - INVENT.inventoryLevel))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public void UpdateUI()
    {
        cashText.text = "Cash:\n$" + cash.ToString("N0"); //Howtobasic teaches you how to print shit onto the screen and does it
        SmaAmt.text = "Amount owned: " + CRATESHOP.crateShop.CRATELIST[0].amountOwned + "\nWorth: $" + CRATESHOP.crateShop.CRATELIST[0].crateSell.ToString("N0");
        MedAmt.text = "Amount owned: " + CRATESHOP.crateShop.CRATELIST[1].amountOwned + "\nWorth: $" + CRATESHOP.crateShop.CRATELIST[1].crateSell.ToString("N0");
        LarAmt.text = "Amount owned: " + CRATESHOP.crateShop.CRATELIST[2].amountOwned + "\nWorth: $" + CRATESHOP.crateShop.CRATELIST[2].crateSell.ToString("N0");
        SpeAmt.text = "Amount owned: " + CRATESHOP.crateShop.CRATELIST[3].amountOwned + "\nWorth: $" + CRATESHOP.crateShop.CRATELIST[3].crateSell.ToString("N0");
        inventory.text = INVENT.inventoryLevel + "/" + INVENT.maxInventory; //Display the amount of inventory available
        upgTxt.text = "Upgrade Level: " + INVENT.upgLvl;

        if (INVENT.upgLvl < 5)
        {
            upgBtn.text = "Upgrade Inventory Level\nLevel " + (INVENT.upgLvl + 1) + " ($" + INVENT.upgCost.ToString("N0") + ")";
        }
        else
        {
            upgBtn.text = "Inventory Level Max (5)";
        }
    }
}
