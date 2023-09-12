using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public List<Mammoth> mammoths = new List<Mammoth>();
    public float increaseAmount = 400f;


    public Transform targetRotation;
    public float rotationSpeed = 5.0f; 
    [SerializeField] bool isRotating = false;
    [SerializeField] Vector3 rotate;

    [SerializeField] float currentSpeed = 3000f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        rotate = targetRotation.localEulerAngles;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SetSpeed(increaseAmount);
            SetRotation(20);
        }    
        else if (Input.GetKeyDown(KeyCode.O))
        {
            SetRotation(-20);
            SetSpeed(-increaseAmount);
        }


        if (isRotating)
        {
            float step = rotationSpeed * Time.deltaTime;

            targetRotation.localEulerAngles = Vector3.Lerp(targetRotation.localEulerAngles, rotate, step);

            if (targetRotation.localEulerAngles.z == rotate.z)
                isRotating = false;
        }
    }

    public void SetSpeed(float _newspeed)
    {
        foreach (Mammoth _mammoth in mammoths)
        {
            _mammoth.moveSpeed = currentSpeed + _newspeed;
        }
    }

    public void SetRotation(float _rotation)
    {
        rotate = new Vector3(0f, 0f, rotate.z + _rotation);
        isRotating = true;
    }
}
