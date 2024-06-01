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
    [SerializeField] Vector2[] plantsSpotsCoordinates;
    [SerializeField] GameObject[] plantsPrefabs;
    [SerializeField] Plants[] whichPlantIsPlantedInTheSpot;
    [SerializeField] int[] plantsPrices;

    private void Start()
    {
        for (int i = 0;i<plantsSpotsCoordinates.Length;i++)
        {
            GameObject instance = Instantiate(plantsPrefabs[(int)whichPlantIsPlantedInTheSpot[i]], plantsSpotsCoordinates[i], Quaternion.identity);            
        }
    }

    public void PlantIsPlanted(int spotTag, Plants plant)
    {
        whichPlantIsPlantedInTheSpot[spotTag] = plant;
        GameObject instance = Instantiate(plantsPrefabs[(int)whichPlantIsPlantedInTheSpot[spotTag]], plantsSpotsCoordinates[spotTag], Quaternion.identity);
    }
}
