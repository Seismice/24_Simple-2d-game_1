using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider playerSlider;

    public void UpdatePlayerHealthBar(float currentValue, float maxValue)
    {
        playerSlider.value = currentValue / maxValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
