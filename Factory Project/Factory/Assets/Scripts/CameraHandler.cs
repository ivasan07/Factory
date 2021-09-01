using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField]
    Camera config1;
    [SerializeField]
    Camera[] config2;
    [SerializeField]
    Camera config3;
    [SerializeField]
    Camera config4;
    [SerializeField]
    Camera config5;
    [SerializeField]
    Camera config6;


    TwinCAT_Handler tcHandler;
    int config;
    void Start()
    {
        tcHandler = TwinCAT_Handler.instance;
        config = -1;
    }

    void hideAllCameras()
    {
        config1.targetDisplay = 1;

        foreach (Camera c in config2)
        {
            c.targetDisplay = 1;
        }

        config3.targetDisplay = 1;
        config4.targetDisplay = 1;
        config5.targetDisplay = 1;
        config6.targetDisplay = 1;
    }

    // Update is called once per frame
    void Update()
    {
        int newConfig = tcHandler.ReadDInt("MAIN", "cameraConfig");

        if (newConfig != config)
        {
            hideAllCameras();
            config = newConfig;
            switch (config)
            {
                case 1:
                    config1.targetDisplay = 0;
                    break;
                case 2:
                    {
                        foreach (Camera c in config2)
                        {
                            c.targetDisplay = 0;
                        }
                    }
                    break;
                case 3:
                    config3.targetDisplay = 0;
                    break;
                case 4:
                    config4.targetDisplay = 0;
                    break;
                case 5:
                    config5.targetDisplay = 0;
                    break;
                case 6:
                    config6.targetDisplay = 0;
                    break;
                default:
                    config1.targetDisplay = 0;
                    break;
            }
        }
    }
}
