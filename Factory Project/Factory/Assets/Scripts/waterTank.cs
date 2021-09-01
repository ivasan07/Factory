using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterTank : MonoBehaviour
{
    TwinCAT_Handler tcHandler;
    bool fill, unfill;

    float maxScale;

    [SerializeField]
    GameObject leftValve;

    [SerializeField]
    GameObject rightValve;

    void Start()
    {
        maxScale = 1.68f;
        tcHandler = TwinCAT_Handler.instance;
        transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        fill = tcHandler.ReadBool("MAIN", "fill");
        unfill = tcHandler.ReadBool("MAIN", "unfill");
        if (unfill != fill)
        {
            if (fill)
            {
                if (transform.localScale.y < maxScale)
                {
                    transform.localScale += (Vector3.up / 10) * Time.deltaTime;
                    transform.position += (Vector3.up / 10) * Time.deltaTime;
                    leftValve.transform.Rotate(Vector3.forward * 10 * Time.deltaTime);
                }
                else
                {
                    tcHandler.WriteBool("MAIN", "fill", false);
                    tcHandler.WriteBool("MAIN", "unfill", false);
                }
            }
            else
            {
                if (transform.localScale.y > 0)
                {
                    transform.localScale -= (Vector3.up / 10) * Time.deltaTime; ;
                    transform.position -= (Vector3.up / 10) * Time.deltaTime;
                    rightValve.transform.Rotate(Vector3.forward *10 * Time.deltaTime);
                }
                else
                {
                    tcHandler.WriteBool("MAIN", "fill", false);
                    tcHandler.WriteBool("MAIN", "unfill", false);
                }
            }
        }
    }
}
