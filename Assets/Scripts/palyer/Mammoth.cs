using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mammoth:MonoBehaviour
{
    public float moveSpeed = 100f;
    [SerializeField] float jumpSpeed = 3800f;
    public float raycastDistance = 0.51f;

    public Rigidbody rb;
    
    LevelManager levelManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        
        levelManager = LevelManager.instance;

        if (levelManager != null)
            levelManager.mammoths.Add(this);
    }

    public virtual void move()
    {
        rb.AddForce(moveSpeed * Time.fixedDeltaTime * Vector3.right,ForceMode.Force);
    }

    public virtual void Jump()
    {
        if(CheckGround() == true)
            rb.AddForce(jumpSpeed * Time.fixedDeltaTime * Vector3.up,ForceMode.VelocityChange);
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
