using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Fire Cannons
        if (Input.GetKey(KeyCode.Space))
        {
            print("Bombs Away!");
        } //To-Do: Check Fire-Rate (timers and that)


        //Fun
        if (Input.GetKey(KeyCode.I))
        {
            rigidBody.AddForce(transform.up * 10);
        }
        if (Input.GetKey(KeyCode.K))
        {
            rigidBody.AddForce(transform.forward * 10);
        }
    }
}
