using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera CameraBehind;
    public Camera CameraFront;
    public Camera CameraTop;
    private int currentCamera;

    
    void Start()
    {
        // Varsayýlan olarak arka kamera aktif olacak
        currentCamera = 1;
        CameraBehind.enabled = true;
        CameraFront.enabled = false;
        CameraTop.enabled = false;
    }

    void Update()
    {
        // C tuþuna basýlýrsa kamera deðiþtirilecek
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Aktif kamera deðiþtirilir ve diðer kameralar kapatýlýr/açýlýr
            if (currentCamera == 1)
            {
                currentCamera = 2;
                CameraBehind.enabled = false;
                CameraFront.enabled = true;
                CameraTop.enabled = false;
            }
            else if (currentCamera == 2)
            {
                currentCamera = 3;
                CameraBehind.enabled = false;
                CameraFront.enabled = false;
                CameraTop.enabled = true;
            }
            else if (currentCamera == 3)
            {
                currentCamera = 1;
                CameraBehind.enabled = true;
                CameraFront.enabled = false;
                CameraTop.enabled = false;
            }
        }
    }
}
