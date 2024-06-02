using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldKeeperScript : MonoBehaviour
{
    private int goldAmount;

    public void IncreeseGoldAmount(int i )
    { 
        goldAmount = i; 
    }
    public int GetGoldAmount()
    { 
        return goldAmount; 
    }

    void Start()
    {
        if (PlayerPrefs.HasKey(PrefsKeys.currentGoldKey))
        {
            goldAmount = PlayerPrefs.GetInt(PrefsKeys.currentGoldKey);
        }
        else
        {
            goldAmount = 0;
            PlayerPrefs.SetInt(PrefsKeys.currentGoldKey, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
