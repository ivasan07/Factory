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

    void Update()
    {
        
    }

    public bool ReadBool(string pou, string variableName)
    {
        try
        {
            var hVar = _tcClient.CreateVariableHandle(pou + "." + variableName);
            var readVariable = _tcClient.ReadAny(hVar, typeof(bool));
            _tcClient.DeleteVariableHandle(hVar);
            return bool.Parse(readVariable.ToString());
        }
        catch (AdsErrorException)
        {
            Debug.LogError("TC Error - reading BOOL failed");
            return false;
        }
    }

    public int ReadDInt(string pou, string variableName)
    {
        var value = 0;
        try
        {
            var hVar = _tcClient.CreateVariableHandle(pou + "." + variableName);
            value = (int)_tcClient.ReadAny(hVar, typeof(int));
            _tcClient.DeleteVariableHandle(hVar);
        }
        catch
        {
            Debug.LogError("TC Error - reading DINT failed");
        }
        return value;
    }

    public bool WriteValue(string pou, string variableName, int value)
    {
        try
        {
            var hVar = _tcClient.CreateVariableHandle(pou + "." + variableName);
            _tcClient.WriteAny(hVar, value);
            _tcClient.DeleteVariableHandle(hVar);
            return true;
        }
        catch (AdsErrorException exc)
        {
            Debug.LogError("TC Write Error " + exc.Message);
        }
        return false;
    }
}
