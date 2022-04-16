using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public CinemachineVirtualCamera[] cams;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchCameraTo(0);
        }
        if ( Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchCameraTo(1);
        }
    }

    public void SwitchCameraTo(int camIndex)
    {
        foreach(CinemachineVirtualCamera cam in cams)
        {
            cam.Priority = 0;
        }

        cams[camIndex].Priority = 1;
    }
}
