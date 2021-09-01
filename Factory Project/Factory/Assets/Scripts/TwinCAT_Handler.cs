using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TwinCAT.Ads;
using UnityEngine.SceneManagement;

public class TwinCAT_Handler : MonoBehaviour
{
    private AdsClient _tcClient = null;

    [SerializeField]
    Text id;
    [SerializeField]
    GameObject wrongMsg;

    public static TwinCAT_Handler instance;

    public void Connect()
    {
        instance = this;
        if (_tcClient == null)
            _tcClient = new AdsClient();
        try
        {
            _tcClient.Connect(id.text, 851);
        }
        catch
        {
            wrongMsg.SetActive(true);
        }

        if (_tcClient.IsConnected)
        {
            Debug.Log("Twin CAT ADS port connected");
            SceneManager.LoadScene("Factory");
        }
        else
        {
            Debug.LogError("ADS Connection failed");
            wrongMsg.SetActive(true);
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
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

    public float ReadReal(string pou, string variableName)
    {
        float value = 0;
        try
        {
            var hVar = _tcClient.CreateVariableHandle(pou + "." + variableName);
            value = (float)_tcClient.ReadAny(hVar, typeof(float));
            _tcClient.DeleteVariableHandle(hVar);
        }
        catch
        {
            Debug.LogError("TC Error - reading REAL failed");
        }
        return value;
    }

    public bool WriteBool(string pou, string variableName, bool value)
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
