using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mammoth:MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float raycastDistance = 0.51f;

    public Rigidbody rb;
    
    LevelManager levelManager;
    public bool gameOver = false;

    public void startAssign()
    {
        rb = GetComponent<Rigidbody>();

        levelManager = LevelManager.instance;

        if (levelManager != null)
            levelManager.mammoths.Add(this);
        gameOver = false;
    }
    public void move()
    {
        rb.AddForce(moveSpeed * Vector3.right * Time.fixedDeltaTime, ForceMode.Force);
    }

    public void Jump()
    {
        if (CheckGround() == true)
        {
            rb.AddForce(jumpSpeed * Vector3.up * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    public bool CheckGround()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {      
            return true;
        }
        return false;
    }
}
