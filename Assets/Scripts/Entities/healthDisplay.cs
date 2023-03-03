using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthDisplay : MonoBehaviour
{
    public Entity target;
    public Slider _slider;

    void Start()
    {
        _slider.maxValue = target.health;
    }

    void Update()
    {
        _slider.value = target.health;
    }
}
