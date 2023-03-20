using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] GameObject muzzleFlash;
    [SerializeField] ParticleSystem rocketBlast;
    [SerializeField] ParticleSystem zombieBlood;
    bool isActive =false;
     
    public Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammo;
    bool canShoot = true;
    private void Awake()
    {
        muzzleFlash.SetActive(false);
    }
    void Start()
    {
        
        ammoSlot = FindObjectOfType<Ammo>();
        GetComponent<Animation>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        ammo.SetText(ammoSlot.GetCurrentAmmo(ammoType).ToString() + "/" + ammoSlot.GetAmmo(ammoType).ToString());
        if (Input.GetMouseButton(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.GetCurrentAmmo(ammoType)>=0)
        {
            GetComponent<AudioSource>().Play();
            StartCoroutine(FireAnimation());
            StartCoroutine(ReloadAnimation());
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
            //ammo.SetText(ammoSlot.GetCurrentAmmo(ammoType).ToString() + "/" + ammoSlot.GetAmmo(ammoType).ToString());
        }
        yield return new WaitForSeconds(.5f);
        canShoot = true;
    }
    private IEnumerator ReloadAnimation()
    {
        GetComponent<Animation>().Play();
        yield return new WaitForSeconds(.25f);
        GetComponent<Animation>().Stop();
    }
    private IEnumerator FireAnimation()
    { 
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(.01f);
        muzzleFlash.SetActive(false);
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
            
        }
        else { return; }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        if(hit.collider.tag=="Enemy")
        {
            var Impact = Instantiate(zombieBlood, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(Impact.gameObject, .8f);
        }
        if(gameObject.tag== "RocketLauncher")
        {
            var Impact = Instantiate(rocketBlast, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(Impact.gameObject, 1f);
        }
    }
    public void SetActiveWeapon()
    {
        isActive = true;
        Debug.Log(isActive);
    }

    public bool IsActive()
    {
        return isActive;
    }
}
