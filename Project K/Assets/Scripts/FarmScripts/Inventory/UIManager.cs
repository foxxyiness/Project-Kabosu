using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public static UIManager Instance { get; private set; }

    [Header("Inventory System")]

    public GameObject inventoryPanel;

    public InventorySlot[] toolSlots;
    public InventorySlot[] itemSlots;


    //item info box
    public Text itemNameText;
    public Text itemDescriptionText;

    private void Awake()
    {
        //destroys extra instances if more than one exist
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            //sets static instance to this instance
            Instance = this;
        }
    }


    private void Start()
    {
        RenderInventory();
    }


    //render inventory to screen
    public void RenderInventory()
    {
        //get tool slots
        ItemData[] inventoryToolSlots = InventoryManager.Instance.tools;

        //get item slots
        ItemData[] inventoryItemSlots = InventoryManager.Instance.items;

        //render tool selection
        RenderInventoryPanel(inventoryToolSlots, toolSlots);

        //render item selection
        RenderInventoryPanel(inventoryItemSlots, itemSlots);
    }
    
    //iterate through a slot in a section and display them in the UI
    void RenderInventoryPanel(ItemData[] slots, InventorySlot[] uiSlots)
    {
        
        for (int i = 0; i < uiSlots.Length; i++)
        {
            //display
            uiSlots[i].Display(slots[i]);

        }
    }


    public void ToggleInventoryPanel()
    {
        //if hidden, show. if shown, hide
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);

        RenderInventory();
    }

    //display item info 
    public void DisplayItemInfo(ItemData data)
    {

        //if data is null, reset
        if(data == null)
        {
            itemNameText.text = "";

            itemDescriptionText.text = "";
            return;
        }


        itemNameText.text = data.name;

        itemDescriptionText.text = data.description;
    }

}
