using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Mammoth
{
    void Update()
    {
        move();

        if (Input.GetKeyDown(KeyCode.L))
        {
            Jump();
        }

        int rand = Random.Range(0, 20);

        if (rand == 5)
            Jump();
    }
}
