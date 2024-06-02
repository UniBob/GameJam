using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenKeeperScript : MonoBehaviour
{
    public enum Plants
    {
        Nothing,
        Carrot,
        Tomato,
        Cucumber,
        Onion
    }
       
    [SerializeField] PlantsSpotScript[] plantsSpots;
    [SerializeField] Sprite[] plantsSprites;
    [SerializeField] Plants[] whichPlantIsPlantedInTheSpot;
    [SerializeField] int[] plantsPrices;

    private void Start()
    {
        for (int i = 0; i < whichPlantIsPlantedInTheSpot.Length; i++) 
        {
            if (whichPlantIsPlantedInTheSpot[i] != Plants.Nothing)
            {
                plantsSpots[i].SetSprite(plantsSprites[(int)whichPlantIsPlantedInTheSpot[i]], whichPlantIsPlantedInTheSpot[i] == Plants.Nothing);
            }
        }
    }

    public Sprite PlantIsPlanted(int spotTag, Plants plant)
    {
        whichPlantIsPlantedInTheSpot[spotTag] = plant;
        return plantsSprites[(int)plant];
    }
}
