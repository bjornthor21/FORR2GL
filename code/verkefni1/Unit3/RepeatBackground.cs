using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// þessi skrifta lætur bakgrunninn endurtaka sig við miðju
public class RepeatBackground : MonoBehaviour
{
    // skilgreini byrjunar staðsetningu og enturtekningar staðsetningu
    private Vector3 startPos;
    private float repeatWidth;


    void Start()
    {
        // setur position a bakgrunni í startPos breytuna
        startPos = transform.position;
        // hér er miðjan reiknuð með stærð box collider
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        // ef núverandi staðsetning er minni heldur en startpos - helmingur lengd bakgrunns þá repeatast.
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
