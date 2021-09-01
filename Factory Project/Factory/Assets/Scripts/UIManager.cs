using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    TwinCAT_Handler _tcHandler;


    public Text runBeltText;
    bool runBelt;

    public Text spawnRateText;
    float spawnRate;

    public Text beltSpeedText;
    float beltSpeed;


    public Text dirText;
    int dir;
    bool autoDir;

    public Text cameraConfigText;
    int cameraConfig;

    public Text waterTankText;
    bool fill;
    bool unfill;

    [SerializeField]
    Transform waterTankTr;
    [SerializeField]
    float waterTankMaxCap;
    [SerializeField]
    Text capacityText;
    [SerializeField]
    Text capacity;
    [SerializeField]
    GameObject background2;

    private void Start()
    {
        _tcHandler = TwinCAT_Handler.instance;
    }

    void Update()
    {
        runBelt = _tcHandler.ReadBool("MAIN", "runBelt");
        if (runBelt)
        {
            runBeltText.text = "power: on";
        }
        else runBeltText.text = "power: off";


        spawnRate = _tcHandler.ReadReal("MAIN", "spawnRate");
        spawnRateText.text = "spawn rate: " + spawnRate + " seconds";

        beltSpeed = _tcHandler.ReadReal("MAIN", "boxSpeed");
        beltSpeedText.text = "belt speed: " + beltSpeed;

        autoDir = _tcHandler.ReadBool("MAIN", "autoDirection");
        dir = _tcHandler.ReadDInt("MAIN", "direction");
        if (autoDir) dirText.text = "direction: auto";
        else
        {
            if (dir == 0) dirText.text = "direction: left";
            else dirText.text = "direction: right";
        }

        cameraConfig = _tcHandler.ReadDInt("MAIN", "cameraConfig");
        if (cameraConfig < 1 || cameraConfig > 6) cameraConfig = 1;
        cameraConfigText.text = "camera config: " + cameraConfig;

        fill = _tcHandler.ReadBool("MAIN", "fill");
        unfill = _tcHandler.ReadBool("MAIN", "unfill");

        if (fill == unfill) waterTankText.text = "watertank: off";
        else
        {
            if (fill) waterTankText.text = "watertank: filling";
            else waterTankText.text = "watertank: unfilling";
        }

        if (cameraConfig != 6)
        {
            background2.SetActive(false);
            capacity.enabled = false;
            capacityText.enabled = false;
        }
        else
        {
            background2.SetActive(true);
            capacity.enabled = true;
            capacityText.enabled = true;

            //maxscale - 100
            //scale - x
            int percentage = (int)(waterTankTr.localScale.y * 100 / waterTankMaxCap);
            capacityText.text = percentage + "%";
        }
    }
}
