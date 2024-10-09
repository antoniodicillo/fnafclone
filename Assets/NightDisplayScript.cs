using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NightDisplayScript : MonoBehaviour
{

    [SerializeField] private string NightName;
    [SerializeField] private TextMeshProUGUI NightText;

    [SerializeField] private float TimeToDie;


    // Start is called before the first frame update
    void Start()
    {
        NightText.text = NightName;
        Destroy(gameObject, TimeToDie);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
