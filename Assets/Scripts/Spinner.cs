using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        Spin();
    }

    void Spin()
    {
        rb.AddTorque(0, rotationSpeed * 100 * Time.fixedDeltaTime, 0, ForceMode.Acceleration);
    }
}
