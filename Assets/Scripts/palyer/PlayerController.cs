using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Mammoth
{

    void Update()
    {
        move();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}
