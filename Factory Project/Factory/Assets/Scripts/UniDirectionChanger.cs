using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniDirectionChanger : MonoBehaviour
{
    [SerializeField]
    GameObject newDestiny;

    [SerializeField]
    float speed;


    private void OnTriggerEnter(Collider other)
    {
        ItemMovement movement = other.GetComponent<ItemMovement>();
        if (movement != null)
        {
            movement.speed = speed;
            movement.destiny = newDestiny;
        }
    }
}
