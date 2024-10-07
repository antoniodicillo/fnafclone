using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShiftTimer : MonoBehaviour
{
    [SerializeField] private float Timer;
    [SerializeField] private int ShiftEndTime = 6;
    [SerializeField] private string DigitalClock;

    [SerializeField] private float TimeMultiplier = 0.8f;

    [SerializeField] private TextMeshProUGUI ClockText;

    [SerializeField] private GameObject WinScreen;

    [SerializeField] private bool Won;

    [SerializeField] private AnimatronicSystem[] Animatronics;

    void Start()
    {
        DigitalClock = "";
    }

    void Update()
    {
        if(!Won)
        {
            Timer += Time.deltaTime * TimeMultiplier;

            var hours = Mathf.FloorToInt(Timer / 60);
            var minutes = Mathf.FloorToInt(Timer - hours * 60);

            if(minutes == 0)
            {
                for(int i=0; i<Animatronics.Length;i++)
                {
                    Animatronics[i].ChangeAgressionByHour(hours);
                }
            }

            if (hours >= ShiftEndTime)
            {
                WinScreen.SetActive(true);
                Won = true;
            }
            if (hours == 0)
            {
                hours = 12;
            }
            DigitalClock = string.Format("{0:00}", hours + " AM");

            ClockText.text = DigitalClock;

        }

    }
    
}
