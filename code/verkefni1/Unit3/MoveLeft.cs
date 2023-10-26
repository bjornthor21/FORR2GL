using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// þessi skripta sér um obstacle og bakgrunn, hreyfir þá og eyðir obstacle þegar við á
public class MoveLeft : MonoBehaviour
{
    // skilgreini hraða sem obstacle og bakgrunnur fara á
    private float speed = 30;
    // skilgreinir hvar hlutir eru komnir úr camera view
    private float leftBound = -15;

    // sækir PlayerController skriptuna til að geta notað breytu þaðan
    private PlayerController playerControllerScript;


    // Start keyrir áður en fyrsta frame update.
    void Start()
    {
        // finnur og sækir player
        playerControllerScript = GameObject.Find("player").GetComponent<PlayerController>();
    }

    // update keyrir fyrir hvern frame
    void Update()
    {
        // ef breytan gameOver frá PlayerController.cs er false (Player er ekki buinn að rekast á obstacle)
        // þá hreyfast obstacle og bakgrunnur annars stoppa þeir
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.left);
        }

        // ef obstacle er kominn úr camera view er þeim eytt
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
