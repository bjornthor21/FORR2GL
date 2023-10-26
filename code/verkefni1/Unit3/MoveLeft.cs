using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �essi skripta s�r um obstacle og bakgrunn, hreyfir �� og ey�ir obstacle �egar vi� �
public class MoveLeft : MonoBehaviour
{
    // skilgreini hra�a sem obstacle og bakgrunnur fara �
    private float speed = 30;
    // skilgreinir hvar hlutir eru komnir �r camera view
    private float leftBound = -15;

    // s�kir PlayerController skriptuna til a� geta nota� breytu �a�an
    private PlayerController playerControllerScript;


    // Start keyrir ��ur en fyrsta frame update.
    void Start()
    {
        // finnur og s�kir player
        playerControllerScript = GameObject.Find("player").GetComponent<PlayerController>();
    }

    // update keyrir fyrir hvern frame
    void Update()
    {
        // ef breytan gameOver fr� PlayerController.cs er false (Player er ekki buinn a� rekast � obstacle)
        // �� hreyfast obstacle og bakgrunnur annars stoppa �eir
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.left);
        }

        // ef obstacle er kominn �r camera view er �eim eytt
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
