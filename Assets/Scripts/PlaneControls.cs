using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneControls : MonoBehaviour
{
    [SerializeField] private float constantSpeed = 1.0f;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float elapsedTime;
    [SerializeField] private float timeToMax = 5.0f;
    [SerializeField] private float timer;

    private float initialVelocity;
    private Rigidbody2D rb;
    
    void Start()
    {
        elapsedTime = elapsedTime + Time.fixedDeltaTime;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * constantSpeed;
        rb.rotation = 0f;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            acceleratePlane();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            rb.velocity = Vector2.right * constantSpeed;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.rotation = 45f;
            pitchUp();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            rb.rotation = 0f;
            rb.velocity = Vector2.right * constantSpeed;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.rotation = -45f;
            pitchDown();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.rotation = 0f;
            rb.velocity = Vector2.right * constantSpeed;
        }
    }

    private void acceleratePlane()
    {
        initialVelocity = constantSpeed;
        maxSpeed = Mathf.Lerp(initialVelocity, maxSpeed, elapsedTime);
        rb.velocity = rb.velocity * maxSpeed;

        Debug.Log("Plane Accelerating");
    }

    private void pitchUp()
    {
        rb.rotation += 1.0f;

        rb.velocity = Vector2.up * constantSpeed;
        initialVelocity = constantSpeed;
        maxSpeed = Mathf.Lerp(initialVelocity, maxSpeed, elapsedTime);
        rb.velocity = rb.velocity * maxSpeed;

        Debug.Log("Plane Pitching Up");
    }

    private void pitchDown()
    {
        rb.rotation += 1.0f;

        rb.velocity = Vector2.down * constantSpeed;
        initialVelocity = constantSpeed;
        maxSpeed = Mathf.Lerp(initialVelocity, maxSpeed, elapsedTime);
        rb.velocity = rb.velocity * maxSpeed;

        Debug.Log("Plane Pitching Down");
    }

}


