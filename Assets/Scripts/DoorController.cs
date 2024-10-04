using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Door Door;
    [SerializeField] private PowerSystem Power;

    private void OnMouseDown()
    {
        Door.isOpen = !Door.isOpen;
        Door.GetComponent<AudioSource>().Play();
        if(Door.isOpen)
        {
            Power.SystemsOn--;
        } 
        else
        {
            Power.SystemsOn++;
        }
      
    }
}
