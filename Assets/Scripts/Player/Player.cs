using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Slider slider;

    [Header("Prefabs")]
    [SerializeField] GameObject shotPrefab;
    [SerializeField] Transform shotPosition;

    [Header("Other options")]
    [SerializeField] float fireRate;
    [SerializeField] int currentHealth;
    [SerializeField] int maxHealth;
    [SerializeField] float bulletDamage;

    Animator anim;
    float nextShotTime;
    bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        slider = FindObjectOfType<Slider>();
        isAlive = true;
        SyncronizePrayerParams();
        slider.value = currentHealth;
        anim = GetComponentInChildren<Animator>();
        nextShotTime = Time.time;
    }

    private void SyncronizePrayerParams()
    {
        if (PlayerPrefs.HasKey("maxHealth"))
        {
            maxHealth = PlayerPrefs.GetInt("maxHealth");
        }
        else
        {
            maxHealth = 100;
            PlayerPrefs.SetInt("maxHealth", maxHealth);
        }

        if (PlayerPrefs.HasKey("currentHealth"))
        {
            currentHealth = PlayerPrefs.GetInt("currentHealth");
        }
        else
        {
            currentHealth = maxHealth;
            PlayerPrefs.SetInt("currentHealth", currentHealth);
        }

        if (PlayerPrefs.HasKey("fireRate"))
        {
            fireRate = PlayerPrefs.GetFloat("fireRate");
        }
        else
        {
            fireRate = 0.4f;
            PlayerPrefs.SetFloat("fireRate", fireRate);
        }

        if (PlayerPrefs.HasKey("bulletDamage"))
        {
            bulletDamage = PlayerPrefs.GetFloat("bulletDamage");
        }
        else
        {
            bulletDamage = 10f;
            PlayerPrefs.SetFloat("bulletDamage", bulletDamage);
        }
    }

    public float GetBulletDamage()
    {
        return bulletDamage;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && nextShotTime <= Time.time && isAlive)
        {
            Instantiate(shotPrefab, shotPosition.position, transform.rotation);
            nextShotTime = Time.time + fireRate;
            anim.SetTrigger("Shoot");
        }
    }

    public void GetDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death();
        }
        slider.value = currentHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    void Death()
    {
        isAlive = false;
       // anim.SetBool("isAlive", false);
    }

    public bool GetStatus()
    {
        return isAlive;
    }

    public bool HealBonus(int heal)
    {
        if(currentHealth == maxHealth)
        {
            return false;
        }
        else
        {
            currentHealth += heal;
            return true;
        }
    }
}
