using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDirectionChanger : MonoBehaviour
{
    [SerializeField]
    GameObject newDestiny1;
    [SerializeField]
    GameObject newDestiny2;

    int option = 1;

    [SerializeField]
    float speed1;
    [SerializeField]
    float speed2;


    private void OnTriggerEnter(Collider other)
    {
        ItemMovement movement = other.GetComponent<ItemMovement>();
        if (movement != null)
        {
            if (option == 1)
            {
                option = 2;
                movement.speed = speed1;
                movement.destiny = newDestiny1;
            }
            else
            {
                option = 1;
                movement.speed = speed2;
                movement.destiny = newDestiny2;
            }
        }
    }
}
