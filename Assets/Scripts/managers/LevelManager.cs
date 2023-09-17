using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public List<Mammoth> mammoths = new List<Mammoth>();
    [SerializeField] float currentSpeed = 3000f;
    public float increaseAmount = 400f;


    public Transform targetRotation;
    public float rotationSpeed = 5.0f; 
    [SerializeField] bool isRotating = false;
    [SerializeField] Vector3 rotate;


    bool maxed = false;
    public bool levelCompleted = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        maxed = false;
        rotate = targetRotation.localEulerAngles;
        StartCoroutine(ChangeSpeedCoro());
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
        currentSpeed = currentSpeed + _newspeed;
        foreach (Mammoth _mammoth in mammoths)
        {
            _mammoth.moveSpeed = currentSpeed;
        }
    }

    public void GameOver()
    {
        rotate = new Vector3(0f, 0f, 0f);
        isRotating = true;

        //setting the speed to 0
        foreach (Mammoth _mammoth in mammoths)
        {
            _mammoth.moveSpeed = 0f;
            _mammoth.gameOver = true;
        }
    }

    public void SetRotation(float _rotation)
    {
        rotate = new Vector3(0f, 0f, rotate.z + _rotation);
        isRotating = true;
    }

    IEnumerator ChangeSpeedCoro()
    {
        yield return new WaitForSeconds(Random.Range(10f, 15f));

        if (levelCompleted)
            yield return null;

        if(maxed)
        {
            SetRotation(-20);
            SetSpeed(-increaseAmount);
            maxed = false;
        }
        else
        {
            SetSpeed(increaseAmount);
            SetRotation(20);
            maxed = true;
        }

        StartCoroutine(ChangeSpeedCoro());
    }
}
