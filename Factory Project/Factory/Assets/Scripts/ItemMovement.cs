using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public GameObject destiny;
    public float speed;
    public TwinCAT_Handler _tcHandler;

    private void Start()
    {
        _tcHandler = TwinCAT_Handler.instance;
        speed = _tcHandler.ReadReal("MAIN", "boxSpeed");
        destiny = null;
    }

    void Update()
    {
        bool runBelt = _tcHandler.ReadBool("MAIN", "runBelt");
        if (runBelt)
        {
            float newSpeed = _tcHandler.ReadReal("MAIN", "boxSpeed");

            if (newSpeed != speed)
            {
                speed = newSpeed;
            }

            if (destiny != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, destiny.transform.position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, destiny.transform.position) < 0.2f)
                {
                    destiny = null;
                }
            }
        }
    }
}
