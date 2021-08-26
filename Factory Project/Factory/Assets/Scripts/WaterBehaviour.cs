using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour
{
    [SerializeField]
    float increase = 0;
    [SerializeField]
    float totalScale;

    Vector3 originalScale;

    private void Start()
    {
        originalScale = this.transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        ItemMovement movement = other.GetComponent<ItemMovement>();
        if (movement != null)
        {
            Destroy(other.gameObject);
            this.transform.localScale += Vector3.forward * increase;
            if (this.transform.localScale.z >= totalScale)
            {
                this.transform.localScale = originalScale;
            }
        }

    }
}
