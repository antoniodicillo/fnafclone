using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoqueNoAmigao : MonoBehaviour
{

    [SerializeField] private GameObject amigao;
    [SerializeField] private PowerSystem Power;
    [SerializeField] private GameObject shockButton;

    [SerializeField] private float coolDownChoque = 4f;
    [SerializeField] private float currentCooldownChoque;


    // Start is called before the first frame update
    void Start()
    {
        currentCooldownChoque = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCooldownChoque > 0)
        {
            currentCooldownChoque -= Time.deltaTime;
        }
    }

    public void RestartAmigao() {
        if(currentCooldownChoque <= 0) {
            if(amigao.GetComponent<AnimatronicSystem>().CurrentTarget <= 3)
            {
                amigao.GetComponent<AnimatronicSystem>().CurrentTarget = 0;
            }
            shockButton.GetComponent<AudioSource>().Play();

            currentCooldownChoque = coolDownChoque;
            Power.SystemsOn += 2;
            StartCoroutine(choqueTime());
        }

        IEnumerator choqueTime()
        {
            yield return new WaitForSeconds(2);
            Power.SystemsOn -= 2;
        }
    }


}
