using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BUYBTN : MonoBehaviour
{
    public int crateID; //Crate ID # for each button

    public GameObject BuyScreen; //Message Screen

    private void Update()
    {
        
    }

    public void BuyCrate()
    {
        if (crateID != 4)
        {
            PURCHASE.crID = crateID;
            BuyScreen.SetActive(true);
            return;
        }
        else
        {
            if (TIME.time > 0)
            {
                Debug.Log("You can only buy this item every 60 seconds.");
            }
            else
            {
                PURCHASE.crID = crateID;
                BuyScreen.SetActive(true);
                return;
            }
        }
    }
}
