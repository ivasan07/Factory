using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    float secondsPerItem;
    [SerializeField]
    GameObject prefab;
    public TwinCAT_Handler _tcHandler;

    float counter;
    bool runBelt ;

    private void Start()
    {
        _tcHandler = TwinCAT_Handler.instance;
        secondsPerItem = _tcHandler.ReadReal("MAIN", "spawnRate");
        counter = 0;
    }

    private void Update()
    {
        runBelt = _tcHandler.ReadBool("MAIN", "runBelt");

        if (runBelt)
        {
            float newRate = _tcHandler.ReadReal("MAIN", "spawnRate");
            if (newRate != secondsPerItem)
            {
                secondsPerItem = newRate;
            }


            counter += Time.deltaTime;
            if (counter >= secondsPerItem)
            {
                Spawn();
                counter = 0;
            }

        }
    }

        void Spawn()
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
