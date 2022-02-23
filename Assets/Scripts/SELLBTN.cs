using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SELLBTN : MonoBehaviour
{
    public int crateID; //Crate ID # for each button

    public void SellCrate()
    {
        if (crateID == 0)
        {
            Debug.Log("Error: There is no crate ID currently set."); //If there's no crate found
            return;
        }

        for (int i = 0; i < CRATESHOP.crateShop.CRATELIST.Count; i++)
        {
            if (crateID == CRATESHOP.crateShop.CRATELIST[i].crateID)
            {
                if (CRATESHOP.crateShop.CRATELIST[i].amountOwned > 0)
                {
                    BUYSYS.buy.AddMoney((CRATESHOP.crateShop.CRATELIST[i].crateWorth) * CRATESHOP.crateShop.CRATELIST[i].amountOwned); //Subtract the cost from the cash available
                    INVENT.inventoryLevel -= CRATESHOP.crateShop.CRATELIST[i].amountOwned; //Update crates
                    CRATESHOP.crateShop.CRATELIST[i].amountOwned = 0; //Add one to the current inventory
                    CRATESHOP.crateShop.CRATELIST[i].crateSell = 0;
                }
                else if (CRATESHOP.crateShop.CRATELIST[i].amountOwned < 1)
                {
                    Debug.Log("Error: You do not have any of this item to sell."); //Tell me I can't afford it
                }
            }
        }
    }
}
