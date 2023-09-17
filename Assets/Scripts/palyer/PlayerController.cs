using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Mammoth
{
    private void Start()
    {
        startAssign();
    }

    private void Update()
    {
        if (gameOver)
            return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }

    private void FixedUpdate()
    {
        if (gameOver)
            return;
        move();
    }

}
