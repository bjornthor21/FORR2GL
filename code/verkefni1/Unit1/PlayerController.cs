using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // breytur sem geyma hra�a, beygjuhra�a og horizontal og forward input
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;


    // Start er kalla� ��ur en firsta frame update
    void Start()
    {
        
    }

    // Update er kalla� einu sinni fyrir hvern frame
    void Update()
    {
        // s�kir player input gildi
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // hreyfir b�linn �fram mi�a� vi� Vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // beygir b�lnum mi�a� vi� Horizontal input
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        
}
}
