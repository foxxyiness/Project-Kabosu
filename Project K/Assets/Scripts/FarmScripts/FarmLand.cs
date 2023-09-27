using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLand : MonoBehaviour
{
    public enum LandStatus
    {
        Soil, Farmland, Watered
    }

    public LandStatus landStatus;

    public Material soilMat, farmLandMat, wateredMat;
    /*[SerializeField]
    private new MeshRenderer renderer;*/

    public void Start()
    {
        //get renderer component
       // renderer = GetComponent<MeshRenderer>();

        //set default land status
        SwitchLandStatus(LandStatus.Soil);

    }

    public void SwitchLandStatus(LandStatus statusToSwitch) 
    {
        //set land status
        landStatus = statusToSwitch;

        Material materialToSwitch = soilMat;

        switch (statusToSwitch)
        {
            case LandStatus.Soil:
                materialToSwitch = soilMat;
                //switch to soil material
                break;
            case LandStatus.Farmland:
                materialToSwitch = farmLandMat;
                //switch to Farmland
                break;
            case LandStatus.Watered:
                materialToSwitch = wateredMat;
                //switch to watered
                break;
        }

        //get the renderer to apply the material changes
        this.gameObject.GetComponent<MeshRenderer>().material = materialToSwitch;

    }
    public void Interact()
    {
        //interaction
        Debug.Log("Interacted");
    }




    // Update is called once per frame
    void Update()
    {
   

    
    }
}
