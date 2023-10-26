using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �essi skrifta l�tur bakgrunninn endurtaka sig vi� mi�ju
public class RepeatBackground : MonoBehaviour
{
    // skilgreini byrjunar sta�setningu og enturtekningar sta�setningu
    private Vector3 startPos;
    private float repeatWidth;


    void Start()
    {
        // setur position a bakgrunni � startPos breytuna
        startPos = transform.position;
        // h�r er mi�jan reiknu� me� st�r� box collider
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        // ef n�verandi sta�setning er minni heldur en startpos - helmingur lengd bakgrunns �� repeatast.
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
