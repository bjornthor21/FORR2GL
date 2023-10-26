using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // breytur sem geyma hraða, beygjuhraða og horizontal og forward input
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;


    // Start er kallað áður en firsta frame update
    void Start()
    {
        
    }

    // Update er kallað einu sinni fyrir hvern frame
    void Update()
    {
        // sækir player input gildi
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // hreyfir bílinn áfram miðað við Vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // beygir bílnum miðað við Horizontal input
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        
}
}
