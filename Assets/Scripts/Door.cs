using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private GameObject Light;

    [SerializeField] private Vector3 OpenPos;
    [SerializeField] private Vector3 ClosedPos;

    [SerializeField] private float DoorSpeed;
    public bool isOpen;
    public bool isOn;

    [SerializeField] private PowerSystem Power;

    public AudioSource Audio;
    public AudioClip DoorSound;
    public AudioClip Knock;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = OpenPos;
        isOpen = true;

        ChangeLight();
    }

    // Update is called once per frame
    void Update()
    {
        if(Power.Power > 0f)
        {
            if (isOpen)
            {
                if (transform.position != OpenPos)
                {
                    if (Vector3.Distance(transform.position, OpenPos) <= 0.5f)
                    {
                        transform.position = OpenPos;

                    }
                    else
                    {
                        transform.position = Vector3.Lerp(transform.position, OpenPos, DoorSpeed * Time.deltaTime);
                    }
                }
            }
            else
            {

                if (transform.position != ClosedPos)
                {
                    if (Vector3.Distance(transform.position, ClosedPos) <= 0.5f)
                    {
                        transform.position = ClosedPos;
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(transform.position, ClosedPos, DoorSpeed * Time.deltaTime);
                    }
                }
            }
        } else
        {
            if (transform.position != OpenPos)
            {
                if (Vector3.Distance(transform.position, OpenPos) <= 0.5f)
                {
                    transform.position = OpenPos;

                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, OpenPos, DoorSpeed * Time.deltaTime);
                }
            }
            isOn = true;
            ChangeLight();
        }
      
       
    }
    public void ChangeLight()
    {
        isOn = !isOn;
        if (isOn)
        {
            Light.SetActive(true);
            Light.GetComponent<AudioSource>().Play();
            Power.SystemsOn++;
        }
        else
        {
            Light.SetActive(false);
            Light.GetComponent<AudioSource>().Stop();
            Power.SystemsOn--;
        }
    }
}
