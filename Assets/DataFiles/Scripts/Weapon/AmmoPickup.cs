using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    Ammo ammo;
    [SerializeField] int pickupFRifle = 15;
    private void OnTriggerEnter(Collider collision)
    {
        ammo = FindObjectOfType<Ammo>();
        if (collision.gameObject.tag == "Player")
        {
            pickupFRifle = ammo.GetCurrentAmmo(AmmoType.sniper) + pickupFRifle;
            ammo.FillAmmo(AmmoType.sniper, pickupFRifle);
            Destroy(gameObject);
        }
    }
}
