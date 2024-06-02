using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PrefsKeys
{
    public static string plantedKey = "whichPlantIsPlantedInTheSpot";
    public static string clearLocationKey = "healthOnLocationEnd";
    public static string maxHealthKey = "maxHealth";
    public static string currentHealthKey = "currentHealth";
    public static string fireRateKey = "currentHealth";
    public static string bulletDamageKey = "currentHealth";
    public static string currentGoldKey = "currentGold";
}


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
    [SerializeField] GoldKeeperScript goldKeeper;
    private string plantedKey = "whichPlantIsPlantedInTheSpot";
    private string clearLocationKey = "healthOnLocationEnd";
    private void Start()
    {
        LoadArray(PrefsKeys.plantedKey);

        if (PlayerPrefs.HasKey(PrefsKeys.clearLocationKey))
        {
            int goldMultiplier = PlayerPrefs.GetInt(PrefsKeys.clearLocationKey);
            if (goldMultiplier > 1)
            {                
                PlayerPrefs.SetInt(PrefsKeys.clearLocationKey, 0);
                int goldIncome = 0;
                for (int i = 0; i < whichPlantIsPlantedInTheSpot.Length; i++)
                {                    
                    if (whichPlantIsPlantedInTheSpot[i] != Plants.Nothing)
                    {
                        goldIncome += plantsPrices[(int)whichPlantIsPlantedInTheSpot[i]];
                        plantsSpots[i].SetSprite(plantsSprites[(int)Plants.Nothing], true);
                    }
                }
                goldKeeper.IncreeseGoldAmount((int)(goldIncome*(goldMultiplier/40)));
            }

            else
            {
                for (int i = 0; i < whichPlantIsPlantedInTheSpot.Length; i++)
                {
                    if (whichPlantIsPlantedInTheSpot[i] != Plants.Nothing)
                    {
                        plantsSpots[i].SetSprite(plantsSprites[(int)whichPlantIsPlantedInTheSpot[i]], whichPlantIsPlantedInTheSpot[i] == Plants.Nothing);
                    }
                }
            }
        }
        else
        {
            PlayerPrefs.SetInt(PrefsKeys.clearLocationKey, 0);
            for (int i = 0; i < whichPlantIsPlantedInTheSpot.Length; i++)
            {
                if (whichPlantIsPlantedInTheSpot[i] != Plants.Nothing)
                {
                    plantsSpots[i].SetSprite(plantsSprites[(int)whichPlantIsPlantedInTheSpot[i]], whichPlantIsPlantedInTheSpot[i] == Plants.Nothing);
                }
            }
        }
    }

    public void SaveSpotsStatus(string key)
    {
        string json = JsonUtility.ToJson(new Serialization<Plants>(whichPlantIsPlantedInTheSpot));
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }

    [System.Serializable]
    private class Serialization<T>
    {
        [SerializeField]
        private T[] items;

        public Serialization(T[] items)
        {
            this.items = items;
        }

        public T[] ToArray()
        {
            return items;
        }
    }


    void LoadArray(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string json = PlayerPrefs.GetString(key);
            whichPlantIsPlantedInTheSpot = JsonUtility.FromJson<Serialization<Plants>>(json).ToArray();
        }
    }

    public Sprite PlantIsPlanted(int spotTag, Plants plant)
    {
        whichPlantIsPlantedInTheSpot[spotTag] = plant;
        return plantsSprites[(int)plant];
    }
}
