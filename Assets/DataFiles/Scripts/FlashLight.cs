using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;
    Light mylight;
    BatteryFill batteryFill;
    void Start()
    {
        mylight = GetComponent<Light>();
        batteryFill = FindObjectOfType<BatteryFill>();
    }
    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }
    public float GetIntensity()
    {
        return mylight.intensity;
    }
    public float GetSpotAngle()
    {
        return mylight.spotAngle;
    }
    public void IncreaseSpotAngle(float ang)
    {
        mylight.spotAngle = ang;
    }

    public void IncreaseLightIntensity(float intensity)
    {
        mylight.intensity += intensity;
    }

    private void DecreaseLightIntensity()
    {
        if(mylight.intensity!=0)
        {
            mylight.intensity -= lightDecay*Time.deltaTime;
            batteryFill.DecreaseBattery(mylight.intensity);
        }
    }

    private void DecreaseLightAngle()
    {
        if(mylight.spotAngle<=minimumAngle)
        {
            return;
        }
        else
        {
            mylight.spotAngle -= angleDecay * Time.deltaTime;
        }

    }
}
