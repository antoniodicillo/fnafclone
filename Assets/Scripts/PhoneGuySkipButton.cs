using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneGuySkipButton : MonoBehaviour
{
    public GameObject audiothingy;
    public GameObject skipButton;
    public float timeToDestroy;

    void Start()
    {
        StartCoroutine(Skibid());
    }

    IEnumerator Skibid()
    {
        yield return new WaitForSeconds(2);
        audiothingy.SetActive(true);
        skipButton.SetActive(true);
        audiothingy.GetComponent<AudioSource>().Play();
        Destroy(skipButton, timeToDestroy);
        Destroy(audiothingy, timeToDestroy);
    }

}
