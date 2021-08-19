using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour
{
    [SerializeField]
    float increase = 0;

    private void OnTriggerEnter(Collider other)
    {
        ItemMovement movement = other.GetComponent<ItemMovement>();
        if (movement != null)
        {
            Destroy(other.gameObject);
            this.transform.localScale += Vector3.forward * increase;
        }

    }
}
