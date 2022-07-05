using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrustSpeed = 1000.0f;
    [SerializeField] float rotationSpeed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(Vector3.back);
        }
    }

    private void ApplyRotation(Vector3 direction)
    {
        // Need to freeze rotation in the physics engine when we apply our manual rotation
        rb.freezeRotation = true;
        transform.Rotate(direction * rotationSpeed * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
