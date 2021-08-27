using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;
    [SerializeField] string laserName;

    public int GetDamage() { return damage; }

    public string getLaserName(){
        return laserName;
    }
    public void Hit()
    {
        Destroy(gameObject);
    }
}
