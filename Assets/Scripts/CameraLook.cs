using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    [SerializeField] private float CameraSens = 100f;

    [SerializeField] private float MinLookDist;
    [SerializeField] private float MaxLookDist;

    float camLookDistance;
    // Start is called before the first frame update
    void Start()
    {
        camLookDistance = transform.localRotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        camLookDistance = Mathf.Clamp(camLookDistance + Input.GetAxis("Mouse X") * CameraSens, MinLookDist, MaxLookDist);
        transform.localRotation = Quaternion.Euler(0f, camLookDistance, 0f);
    }
}
