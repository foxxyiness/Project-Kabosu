using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class InventoryVr : MonoBehaviour
{

    public GameObject Inventory;
    public GameObject Anchor;
    bool UIActive;

    public static InputFeatureUsage<bool> secondaryButton;

    private void Start()
    {
        //set inventory closed at start
        Inventory.SetActive(false);
        UIActive = false;
    }

    
    private void Update()
    {

        if (secondaryButton = true)
        {
            UIActive = !UIActive;
            Inventory.SetActive(UIActive);
        }
        if(UIActive)
        {
            Inventory.transform.position = Anchor.transform.position;
            Inventory.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
    }
}
