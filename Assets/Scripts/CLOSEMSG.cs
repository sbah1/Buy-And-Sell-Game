using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CLOSEMSG : MonoBehaviour
{
    public GameObject message;
    public InputField inputField;
    public Text displayCost;

    public static CLOSEMSG close;

    void Start()
    {
        close = this;
    }

    public void closeMessage()
    {
        if(!inputField)
        {
            ;
        }
        else
        {
            message.SetActive(false);
            inputField.text = "";
            displayCost.text = "Cost:\n$0";
        }
    }
}
