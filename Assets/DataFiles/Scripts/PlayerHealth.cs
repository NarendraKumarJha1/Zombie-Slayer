using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float hitpoints = 1f;
    FlashLight flashLight;
    HealthBar healthBar;
    [SerializeField] GameObject deathEffect;
    [SerializeField] AudioClip warning;
    [SerializeField] AudioClip pickUpSound;
    private void Awake()
    {
        deathEffect.SetActive(false);
       
    }
    private void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
        /*healthBar.SetHealth(hitpoints);*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Battery")
        {
            flashLight = GetComponentInChildren<FlashLight>();
            if(flashLight.GetIntensity()<10 && flashLight.GetSpotAngle()<66)
            {
                IncreaseFlash(other);
            }
            else
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.clip = warning;
                audioSource.Play();
            }

        }
        if(other.tag=="Uzi")
        {
            other.gameObject.GetComponent<Weapon>().SetActiveWeapon();
        }

        


    }

    private void IncreaseFlash(Collider other)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = pickUpSound;
        audioSource.Play();
        flashLight.IncreaseLightIntensity(10f);
        flashLight.IncreaseSpotAngle(66f);
        Destroy(other.gameObject);
    }

    public void TakeDamage(float damage)
    {
        if (hitpoints > 0)
        {
            hitpoints -= damage;
            Debug.Log(hitpoints);
            healthBar.DecreaseHealthBar(damage);
            StartCoroutine(EnableDeathCanva());
        }
        else
        {
            Debug.Log("Dead you player");
            GetComponent<DeathHandler>().GameOver();
        }
    }

    IEnumerator EnableDeathCanva()
    {
        deathEffect.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        deathEffect.SetActive(false);
    }
}
