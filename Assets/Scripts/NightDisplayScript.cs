using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NightDisplayScript : MonoBehaviour
{

    [SerializeField] private string NightName;
    [SerializeField] private TextMeshProUGUI NightText;

    [SerializeField] private float TimeToDie;

    [SerializeField] private GameObject nightGui;

    // Start is called before the first frame update
    void Start()
    {
        nightGui.SetActive(true);
        NightText.text = NightName;
        Destroy(nightGui, TimeToDie);
    }
}
