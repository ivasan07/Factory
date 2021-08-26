using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDirectionChanger : MonoBehaviour
{
    TwinCAT_Handler _tcHandler;


    [SerializeField]
    GameObject newDestiny1;
    [SerializeField]
    GameObject newDestiny2;

    int option = 1;

    bool auto = true;
    int dir = 0;

    private void Start()
    {
        _tcHandler = TwinCAT_Handler.instance;
    }

    private void Update()
    {

        auto = _tcHandler.ReadBool("MAIN", "autoDirection");
        dir = _tcHandler.ReadDInt("MAIN", "direction");

    }

    private void OnTriggerEnter(Collider other)
    {
        ItemMovement movement = other.GetComponent<ItemMovement>();
        if (movement != null)
        {
            if (auto)
            {
                if (option == 1)
                {
                    option = 2;
                    movement.destiny = newDestiny1;
                }
                else
                {
                    option = 1;
                    movement.destiny = newDestiny2;
                }
            }
            else
            {
                if (dir == 0) movement.destiny = newDestiny1;
                else movement.destiny = newDestiny2;
            }
        }
    }
}
