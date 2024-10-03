using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{

    [SerializeField] private GameObject[] Cameras;

    [SerializeField] private int CurrentCam;

    [SerializeField] private KeyCode OpenCamera;

    [SerializeField] private bool CameraOpened;

    [SerializeField] private GameObject MainCamera;

    [SerializeField] private float CooldownTimer;
    [SerializeField] private float CooldownTime = 0.5f;

    [SerializeField] private GameObject CameraSystemUI;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<Cameras.Length;i++)
        {
            Cameras[i].SetActive(false);
        }
        CameraSystemUI.SetActive(false);
        MainCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(OpenCamera))
        {
            CameraOpened = !CameraOpened;
            ShowCamera();
        }

        if(CooldownTimer <= 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                Cameras[CurrentCam].SetActive(false);
                CurrentCam++;
                if (CurrentCam >= Cameras.Length)
                {
                    CurrentCam = 0;
                }
                GoToCamera(CurrentCam);
                CooldownTimer = CooldownTime;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                Cameras[CurrentCam].SetActive(false);
                CurrentCam--;
                if (CurrentCam < 0)
                {
                    CurrentCam = Cameras.Length - 1;
                }
                GoToCamera(CurrentCam);
                CooldownTimer = CooldownTime;
            }
        } else
        {
            CooldownTimer -= Time.deltaTime;
        }

       
    }
    private void ShowCamera()
    {
        if(CameraOpened)
        {
            Cameras[CurrentCam].SetActive(true);
            CameraSystemUI.SetActive(true);
            MainCamera.SetActive(false);
        }
        else
        {
            Cameras[CurrentCam].SetActive(false);
            CameraSystemUI.SetActive(false);
            MainCamera.SetActive(true);
        }
    }
    public void GoToCamera(int Progression)
    {
        Cameras[CurrentCam].SetActive(false);
        CurrentCam = Progression;
        ShowCamera();
    }
}
