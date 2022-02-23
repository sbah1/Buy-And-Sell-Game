using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PURCHASE : MonoBehaviour
{
    public int costOfCrates; //Cost of the crate
    public int reqCrates = 0; //Requested amt of crates
    public static int crID; //Recieves crate ID #

    public Text requestedAmt; //Input field
    public Text costText; //Display cost of crates to this
    public Text availableCashText; //Display your cash to this
    public Button crateSpecial;

    void Update()
    {
        if (!requestedAmt || !costText || !availableCashText)
        {
            ;
        }
        else
        {
            if (requestedAmt.text == "")
            {
                costOfCrates = 0;
                costText.text = "Cost:\n$0";
                availableCashText.text = "Available cash:\n$" + BUYSYS.buy.cash.ToString("N0");
                availableCashText.color = new Color(50f / 255f, 50f / 255f, 50f / 255f);
            }
            else
            {
                if (crID == 0)
                {
                    ;
                }
                else
                {
                    reqCrates = Convert.ToInt32(requestedAmt.text); //Set the required amount of crates = to the input
                    costOfCrates = reqCrates * CRATESHOP.crateShop.CRATELIST[crID - 1].crateCost; //Calculate the cost of the crates
                    costText.text = "Cost:\n$" + costOfCrates.ToString("N0");
                    availableCashText.text = "Available cash:\n$" + BUYSYS.buy.cash.ToString("N0");

                    if (costOfCrates > BUYSYS.buy.cash)
                    {
                        availableCashText.color = new Color(1, 0, 0);
                        return;
                    }
                    else if (costOfCrates == BUYSYS.buy.cash)
                    {
                        availableCashText.color = new Color(1, 1, 0);
                        return;
                    }
                    else
                    {
                        availableCashText.color = new Color(50f/255f, 50f/255f, 50f/255f);
                        return;
                    }
                }
            }
        }

        if (!crateSpecial)
        {
            ;
        }
        else
        {
            if (TIME.time < 0.001)
            {
                crateSpecial.enabled = true;
            }
            else
            {
                ;
            }
        }
    }

    public void makePurchase()
    {
        if (crID == 4)
        {
            if (CRATESHOP.crateShop.CRATELIST[3].amountOwned + reqCrates <= (INVENT.maxInventory * 0.2))
            {
                if (BUYSYS.buy.ReqSpace(reqCrates))
                {
                    if (BUYSYS.buy.ReqMoney(costOfCrates))
                    {
                        BUYSYS.buy.RemMoney(costOfCrates);
                        CRATESHOP.crateShop.CRATELIST[3].amountOwned += reqCrates;
                        CLOSEMSG.close.closeMessage();
                        TIME.time = 60;
                        crateSpecial.enabled = false;
                        return;
                    }
                    else
                    {
                        Debug.Log("You cannot afford these crates.");
                        return;
                    }
                }
                else
                {
                    Debug.Log("You do not have the space for this item.");
                    return;
                }
            }
            else
            {
                Debug.Log("You can only own up to " + INVENT.maxInventory * 0.2 + " of this item.");
                return;
            }
        }
        else
        {
            for (int i = 0; i < CRATESHOP.crateShop.CRATELIST.Count; i++)
            {
                if (crID == CRATESHOP.crateShop.CRATELIST[i].crateID)
                {
                    if (BUYSYS.buy.ReqSpace(reqCrates))
                    {
                        if (BUYSYS.buy.ReqMoney(costOfCrates))
                        {
                            BUYSYS.buy.RemMoney(costOfCrates);
                            CRATESHOP.crateShop.CRATELIST[i].amountOwned += reqCrates;
                            CLOSEMSG.close.closeMessage();
                            return;
                        }
                        else
                        {
                            Debug.Log("You cannot afford these crates.");
                            return;
                        }
                    }
                    else
                    {
                        Debug.Log("You do not have the space for this item.");
                        return;
                    }
                }
            }
        }
    }
}
