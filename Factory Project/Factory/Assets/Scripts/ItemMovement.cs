using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public GameObject destiny;
    public float speed;

    private void Start()
    {
        speed = 0;
        destiny = null;
    }

    void Update()
    {
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
