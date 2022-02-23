using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INVENT : MonoBehaviour
{
    public static int inventoryLevel; //Inventory level
    public static int maxInventory; //Maximum available storage
    public static int upgLvl; //Inventory upgrade level
    public static int upgCost = 54200;

    void Start()
    {
        inventoryLevel = 0;
        maxInventory = 25;
        upgLvl = 1;
    }

    void Update()
    {
        inventoryLevel = (CRATESHOP.crateShop.CRATELIST[0].amountOwned) + (CRATESHOP.crateShop.CRATELIST[1].amountOwned) +
            (CRATESHOP.crateShop.CRATELIST[2].amountOwned) + (CRATESHOP.crateShop.CRATELIST[3].amountOwned);
    }

    public void Upgrade()
    {
        if (upgLvl < 5)
        {
            if (BUYSYS.buy.ReqMoney(upgCost))
            {
                BUYSYS.buy.RemMoney(upgCost);
                upgLvl += 1; //Adds to the upgrade level
                maxInventory = upgLvl * 25;

                if (upgLvl == 4)
                {
                    upgCost *= 5;
                }
                else
                {
                    upgCost *= 12;
                }
            }
            else
            {
                Debug.Log("You cannot afford to upgrade your warehouse right now.");
            }
        }
        else
        {
            Debug.Log("You have reached the maximum upgrade level for your inventory.");
        }

        if (upgLvl > 5 || upgLvl < 0)
        {
            upgLvl = 1;
            maxInventory = upgLvl * 25;
        }
    }
}
