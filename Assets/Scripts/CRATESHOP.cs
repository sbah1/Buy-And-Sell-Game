using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRATESHOP : MonoBehaviour
{
    public List<CRATEDATA> CRATELIST = new List<CRATEDATA>(); //Creates an array of these. Think of it as a struct from C Base code.

    public static CRATESHOP crateShop;
    
    // Use this for initialization
	void Start ()
    {
        crateShop = this;
	}

    void Update()
    {
        for (int i = 0; i < CRATELIST.Count; i++)
        {
            CRATELIST[i].crateSell = CRATELIST[i].amountOwned * CRATELIST[i].crateWorth;
        }
    }
}
