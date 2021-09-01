using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    float speed;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, speed, 0), ForceMode.VelocityChange);
    }
}
