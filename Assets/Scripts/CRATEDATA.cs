using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Allows for variables to be modified
public class CRATEDATA
{
    public string crateName; //Crate Name
    public int crateID; //Crate ID #
    public int crateCost; //Crate Cost
    public int crateWorth; //How much each crate sells for
    public int crateSell; //How much your inventory level is worth
    public int amountOwned = 0; //Inventory level - must be initialized as each one starts with 0
}