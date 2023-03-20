using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }
    void Update()
    { 
        
    }
    public void DecreaseHealthBar(float damage)
    {
        image.fillAmount -= damage;
    }
    public void SetHealth(float hitpoint)
    {
        image.fillAmount = hitpoint;
    }

}
