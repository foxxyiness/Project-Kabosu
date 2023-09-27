using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Items/Item")]
public class ItemData : ScriptableObject
{
    public string description;

    //UI item icon
    public Sprite thumbnail;


    //game object to show on screen
    public GameObject gameModel;
}
