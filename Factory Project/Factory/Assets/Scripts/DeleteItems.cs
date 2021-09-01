using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItems : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ItemMovement movement = other.GetComponent<ItemMovement>();
        Platform plat = other.GetComponent<Platform>();
        if (movement != null || plat != null)
        {
            Destroy(other.gameObject);
        }

    }
}
