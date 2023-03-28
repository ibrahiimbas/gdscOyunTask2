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
        // Varsay�lan olarak arka kamera aktif olacak
        currentCamera = 1;
        CameraBehind.enabled = true;
        CameraFront.enabled = false;
        CameraTop.enabled = false;
    }

    void Update()
    {
        // C tu�una bas�l�rsa kamera de�i�tirilecek
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Aktif kamera de�i�tirilir ve di�er kameralar kapat�l�r/a��l�r
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
