using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fotos : MonoBehaviour
{
    [SerializeField] private Texture[] fotos;

    [SerializeField] private float CoolDownTime = 5f;
    [SerializeField] private float CoolDownTimer;

    [SerializeField] private float currentFoto = 0;
    
    void Start()
    {
        CoolDownTimer = CoolDownTime;
    }

    // Update is called once per frame
    void Update()
    {
        CoolDownTimer -= Time.deltaTime;
        currentFoto = Random.Range(0, fotos.Length);
    
    }
}
