using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerSystem : MonoBehaviour
{
    public int SystemsOn;

    [SerializeField] private float Power = 100;

    [SerializeField] private TextMeshProUGUI PowerText;

    void Start()
    {
        SystemsOn = 1;
    }

 
    void Update()
    {
        if(SystemsOn < 1)
        {
            SystemsOn = 1;
        }


        if(SystemsOn == 1)
        {
            Power -= 0.05f * Time.deltaTime;
        } 
        else if (SystemsOn == 2)
        {
            Power -= 0.25f * Time.deltaTime;
        }
        else if (SystemsOn == 3)
        {
            Power -= 0.55f * Time.deltaTime;
        }
        else if (SystemsOn == 4)
        {
            Power -= 0.85f * Time.deltaTime;
        }
        else if(SystemsOn == 5)
        {
            Power -= 1.15f * Time.deltaTime;
        }
        else
        {
            Power -= 2f * Time.deltaTime;
        }
        var power = string.Format("{0:0}", Power);
        PowerText.text = $"{power}%";
    }
}
