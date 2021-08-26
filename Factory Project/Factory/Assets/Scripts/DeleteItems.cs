using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItems : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ItemMovement movement = other.GetComponent<ItemMovement>();
        if (movement != null)
        {
            Destroy(other.gameObject);
        }

    }
}
