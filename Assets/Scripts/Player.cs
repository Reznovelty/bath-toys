using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    private Rigidbody rigidBody;

    public float acceleration = 30f;
    public float maxSpeed = 60f;
    public float brakeAcceleration = 50f;
    private float currentSpeed = 0f;

    public float steerSpeed = 10f;
    private float steerInput;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Acceleration
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += acceleration * Time.deltaTime;
            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentSpeed -= brakeAcceleration * Time.deltaTime;
            if (currentSpeed < 0f)
            {
                currentSpeed = 0f;
            }
        }

        //Slow Down (Less) When Not Accelerating or Decelerating
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            currentSpeed -= (brakeAcceleration / 3) * Time.deltaTime;
            if (currentSpeed < 0f)
            {
                currentSpeed = 0f;
            }
        }

        steerInput = 0f;
        //Steering
        if (Input.GetKey(KeyCode.A))
        {
            steerInput = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            steerInput = 1f;
        }

        //transform.Rotate(Vector3.up * turnInput * steerSpeed * Time.deltaTime);

    }

    void FixedUpdate()
    {
        Vector3 moveDir = transform.forward * currentSpeed;
        print(currentSpeed);

        /*rigidBody.linearVelocity = new Vector3(
            moveDir.x,
            rigidBody.linearVelocity.y,
            moveDir.z
            );*/
        //rigidBody.linearVelocity = transform.forward * currentSpeed;

        rigidBody.AddForce(moveDir);

        rigidBody.AddTorque(
            Vector3.up * steerInput * steerSpeed);

    }
}