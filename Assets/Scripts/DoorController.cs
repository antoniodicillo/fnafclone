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

        Door.Audio.clip = Door.DoorSound;
        Door.Audio.Play();

        
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
