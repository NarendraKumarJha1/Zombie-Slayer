using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryFill : MonoBehaviour
{
    Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }
    void Update()
    {

    }
    public void DecreaseBattery(float decreaseAmount)
    {
        image.fillAmount= decreaseAmount*0.1f;
    }
    public void FillBattery(float fillValue)
    {
        image.fillAmount = fillValue;
    }
}
