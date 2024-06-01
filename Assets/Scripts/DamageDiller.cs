using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]

public class DamageDiller : MonoBehaviour
{
    [SerializeField] float damage;
    public float GetDamage() { return damage; }
    public void IncreaseDamage(float dam) { damage += dam; }    
}
