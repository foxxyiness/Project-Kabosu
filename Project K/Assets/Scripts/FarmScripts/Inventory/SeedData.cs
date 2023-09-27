using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Items/Seed")]
public class SeedData : ItemData
{
    //time needed until harvestable
    public int daysToGrow;

    //crop the plant produces
    public ItemData cropToYeild;

    //seedling game object
    public GameObject seedling;

}
