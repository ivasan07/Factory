using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    float secondsPerItem;
    [SerializeField]
    GameObject prefab;

    float counter;

    private void Start()
    {
        counter = 0;
    }

    private void Update()
    {
        counter += Time.deltaTime;
        if (counter >= secondsPerItem)
        {
            Spawn();
            counter = 0;
        }
    }

    void Spawn()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
