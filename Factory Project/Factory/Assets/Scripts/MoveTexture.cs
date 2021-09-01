using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTexture : MonoBehaviour
{
    TwinCAT_Handler tcHandler;
    float scroll;
    float width;
    void Start()
    {
        width = gameObject.transform.localScale.x;
        tcHandler = TwinCAT_Handler.instance;
        scroll = tcHandler.ReadReal("MAIN", "boxSpeed") / width;
    }

    // Update is called once per frame
    void Update()
    {
        bool runBelt = tcHandler.ReadBool("MAIN", "runBelt");
        if (runBelt)
        {
            scroll = tcHandler.ReadReal("MAIN", "boxSpeed") / width;
            float offset = Time.time * scroll;
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}
