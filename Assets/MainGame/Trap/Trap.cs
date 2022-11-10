using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    public int GetDamage() { return damage; }
    public void SetDamage(int damage) { this.damage = damage; }

}
