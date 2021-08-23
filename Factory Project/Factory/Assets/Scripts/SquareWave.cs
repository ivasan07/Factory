using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareWave : MonoBehaviour
{

    [SerializeField]
    public TwinCAT_Handler _tcHandler;
    public string sPouName;             // Beckhoff POU name
    public string sStateName;           // Output variable name
    public string sPulseLengthName;     // Pulse length variable name
    public int iPulseLength;

    private int iLastWrittenPulseLength;
    private bool bState;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        readState();
        writePulseLenght();
    }

    private void readState()
    {
        bState = _tcHandler.ReadBool(sPouName, sStateName);
        toggleColor(bState);
    }

    private void writePulseLenght()
    {
        if (iLastWrittenPulseLength != iPulseLength)
        {
            if (_tcHandler.WriteValue(sPouName, sPulseLengthName,
                iPulseLength))
            {
                iLastWrittenPulseLength = iPulseLength;
            }
        }
    }

    private void toggleColor(bool state)
    {
        var objectRendered = gameObject.GetComponent<Renderer>();
        if (state)
        {
            if (objectRendered != null)
            {
                // red for TRUE
                objectRendered.material.color = new Color(255, 0, 0);
            }
        }
        else
        {
            if (objectRendered != null)
            {
                // green for FALSE
                objectRendered.material.color = new Color(0, 255, 0);
            }
        }
    }
}

