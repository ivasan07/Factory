using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    GameObject platform;

    private void OnTriggerEnter(Collider other)
    {
        ItemMovement movement = other.GetComponent<ItemMovement>();
        if (movement != null)
        {
            movement.destiny = null;

            GameObject platformSpawned = Instantiate(platform, transform.position, Quaternion.identity);
        }
    }
}
