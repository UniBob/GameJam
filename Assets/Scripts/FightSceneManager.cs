using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FightSceneManager : MonoBehaviour
{
    [Header("UIPrefabs")]
    [SerializeField] GameObject goldUIElementPrefab;
    [SerializeField] Vector2 goldUIElementCoordinates;
    [SerializeField] GameObject healthBarPrefab;
    [SerializeField] Vector2 healthBarCoordinates;

    [Header("EnemyesPrefabs")]
    [SerializeField] GameObject[] Enemyes;

    [Header("Stages")]
    [SerializeField] GameObject[] stages;

    private int stage;
    private int enemyesOnStage;

    private void Start()
    {
        GameObject gold = Instantiate(goldUIElementPrefab, goldUIElementCoordinates, Quaternion.identity);
        GameObject hpBar = Instantiate(healthBarPrefab, healthBarCoordinates, Quaternion.identity);
        if (PlayerPrefs.HasKey(PrefsKeys.stage))
        {
            stage = PlayerPrefs.GetInt(PrefsKeys.stage);
        }
        else
        {
            stage = 1;
            PlayerPrefs.SetInt(PrefsKeys.stage, stage);
        }

        if (PlayerPrefs.HasKey(PrefsKeys.enemyesOnStage))
        {
            enemyesOnStage = PlayerPrefs.GetInt(PrefsKeys.enemyesOnStage);
        }
        else
        {
            enemyesOnStage = 1;
            PlayerPrefs.SetInt(PrefsKeys.enemyesOnStage, enemyesOnStage);
        }
        AddEnemyesOnStage();
    }

    private void AddEnemyesOnStage()
    {
        int enemyCount = enemyesOnStage;
        while (enemyCount>32768)
        {
            Instantiate(Enemyes[3], GetRandomCoordinatesForEnemy(), Quaternion.identity);
            enemyCount -= 32768;
        }
        while (enemyCount > 1024)
        {
            Instantiate(Enemyes[2], GetRandomCoordinatesForEnemy(), Quaternion.identity);
            enemyCount -= 1024;
        }
        while (enemyCount > 32)
        {
            Instantiate(Enemyes[1], GetRandomCoordinatesForEnemy(), Quaternion.identity);
            enemyCount -= 32;
        }
        while (enemyCount > 1)
        {
            Instantiate(Enemyes[0], GetRandomCoordinatesForEnemy(), Quaternion.identity);
            enemyCount -= 1;
        }
    }

    private Vector2 GetRandomCoordinatesForEnemy()
    {
        return new Vector2(0,0);
    }

    public void EnemyDeath(int tag)
    {
        int tmp = 1;
        for (int i = tag;i>0;i--)
        {
            tmp *= 32;
        }
        enemyesOnStage -= tmp;
        if (enemyesOnStage <= 0)
        {
            Win();
        }
    }

    private void Win()
    {
        stage++;
        enemyesOnStage = PlayerPrefs.GetInt(PrefsKeys.enemyesOnStage);
        enemyesOnStage += stage * 4;
        PlayerPrefs.SetInt(PrefsKeys.enemyesOnStage, enemyesOnStage);
    }
}
