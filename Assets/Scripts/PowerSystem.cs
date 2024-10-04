using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerSystem : MonoBehaviour
{
    public int SystemsOn;

    public float Power = 100;

    private bool poweredDown = false;


    [SerializeField] private TextMeshProUGUI PowerText;

    [SerializeField] private GameObject PowerCub1;
    [SerializeField] private GameObject PowerCub2;
    [SerializeField] private GameObject PowerCub3;
    [SerializeField] private GameObject PowerCub4;
    [SerializeField] private GameObject PowerCub5;


    void Start()
    {
        SystemsOn = 1;
        PowerCub2.SetActive(false);
        PowerCub3.SetActive(false);
        PowerCub4.SetActive(false);
        PowerCub5.SetActive(false);
    }

 
    void Update()
    {
        if (SystemsOn < 1)
        {
            SystemsOn = 1;
        }
        if (Power > 0)
        {
            if (SystemsOn == 1)
            {
                Power -= 0.05f * Time.deltaTime;
                PowerCub2.SetActive(false);
                PowerCub3.SetActive(false);
                PowerCub4.SetActive(false);
                PowerCub5.SetActive(false);
            }
            else if (SystemsOn == 2)
            {
                Power -= 0.25f * Time.deltaTime;
                PowerCub2.SetActive(true);
                PowerCub3.SetActive(false);
                PowerCub4.SetActive(false);
                PowerCub5.SetActive(false);
            }
            else if (SystemsOn == 3)
            {
                Power -= 0.55f * Time.deltaTime;
                PowerCub2.SetActive(true);
                PowerCub3.SetActive(true);
                PowerCub4.SetActive(false);
                PowerCub5.SetActive(false);
            }
            else if (SystemsOn == 4)
            {
                Power -= 0.85f * Time.deltaTime;
                PowerCub2.SetActive(true);
                PowerCub3.SetActive(true);
                PowerCub4.SetActive(true);
                PowerCub5.SetActive(false);
            }
            else if (SystemsOn == 5)
            {
                Power -= 1.15f * Time.deltaTime;
                PowerCub2.SetActive(true);
                PowerCub3.SetActive(true);
                PowerCub4.SetActive(true);
                PowerCub5.SetActive(true);
            }
            else
            {
                Power -= 2f * Time.deltaTime;
                PowerCub2.SetActive(true);
                PowerCub3.SetActive(true);
                PowerCub4.SetActive(true);
                PowerCub5.SetActive(true);
            }
            var power = string.Format("{0:0}", Power);
            PowerText.text = $"{power}%";
        }
        else
        {
            if (poweredDown == false)
            {
                poweredDown = true;
                PowerCub1.SetActive(false);
                PowerCub2.SetActive(false);
                PowerCub3.SetActive(false);
                PowerCub4.SetActive(false);
                PowerCub5.SetActive(false);
                PowerText.text = "";
                //Door.GetComponent<AudioSource>().Play();
            }
        }
    }
}
