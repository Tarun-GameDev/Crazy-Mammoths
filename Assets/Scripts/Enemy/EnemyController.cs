using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Mammoth
{
    private void Start()
    {
        startAssign();
    }

    private void Update()
    {
        if (gameOver)
            return;

        int rand = Random.Range(0, 20);

        if (rand == 5)
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
