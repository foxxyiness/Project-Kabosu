using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }


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

    [Header ("Tools")]
    //tool slots
    public ItemData[] tools = new ItemData[8];
    public ItemData equippedTool = null;

    [Header("Items")]
    //item slots
    public ItemData[] items = new ItemData[8];
    public ItemData equippedItem = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
