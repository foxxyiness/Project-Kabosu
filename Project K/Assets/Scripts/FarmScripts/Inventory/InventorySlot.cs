using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    ItemData itemToDisplay;

    public Image itemDisplayImage;

    public void Display(ItemData itemToDisplay)
    {
        //check if there is an item to display
        if (itemToDisplay != null)
        {
            //switch thumbnail
            itemDisplayImage.sprite = itemToDisplay.thumbnail;
            this.itemToDisplay = itemToDisplay;

            itemDisplayImage.gameObject.SetActive(true);
            return;
        }
        itemDisplayImage.gameObject.SetActive(false);
    }

    //display item info when player mouses over
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.DisplayItemInfo(itemToDisplay);
    }

    //reset when player mouses off
    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.DisplayItemInfo(null);
    }
}
