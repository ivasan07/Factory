using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwinCAT.Ads;

public class TwinCAT_Handler : MonoBehaviour
{
    private AdsClient _tcClient = null;
    

    void Awake()
    {
        _tcClient = new AdsClient();
        _tcClient.Connect("192.168.137.68.1.1", 851);
        if (_tcClient.IsConnected)
        {
            Debug.Log("Twin CAT ADS port connected");
        }
        else
        {
            Debug.LogError("ADS Connection failed");
        }
    }
}
