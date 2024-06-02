using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlantsSpotScript : MonoBehaviour
{
    private bool isPlayerNearby = false;
    private GardenKeeperScript keeper;
    [SerializeField] private int spotTag;
    [SerializeField] GameObject buttonIcon;
    
    private void Start()
    {
        keeper = FindObjectOfType<GardenKeeperScript>();
        buttonIcon.GameObject().active = false;
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            PerformAction();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            isPlayerNearby = true;
            buttonIcon.GameObject().SetActive(true);
        }
    }

    // Вызывается, когда игрок покидает триггер
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            isPlayerNearby = false;
            buttonIcon.GameObject().SetActive(false);
        }
    }

    // Метод для выполнения действия
    void PerformAction()
    {
        keeper.PlantIsPlanted(spotTag, GardenKeeperScript.Plants.Tomato);
    }
}
