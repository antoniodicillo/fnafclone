using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneGuySkip : MonoBehaviour
{
   public void SkipCall(GameObject skipbutton)
    {
        Destroy(gameObject);
        Destroy(skipbutton);
    }
}
