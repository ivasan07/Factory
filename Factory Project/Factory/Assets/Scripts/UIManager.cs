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
    }
}
