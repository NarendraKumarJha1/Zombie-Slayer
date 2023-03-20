using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    [Serializable]
    public class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
        public int totalAmmo;
        
    }
    public int GetAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).totalAmmo;
    }
    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }
    public void FillAmmo(AmmoType ammoType,int fill)
    {
        GetAmmoSlot(ammoType).ammoAmount = fill;
    }
    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }
    public AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType==ammoType)
            {
                return slot;
            }
        }
        return null;
    }

}
