using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // player breytann og offsett (hversu langt fra myndav�linn er fr� player)
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -7);

    void Start()
    {
        
    }

    void LateUpdate()
    {
        // setur cameruna aftan vi� bilinn me� offset
        transform.position = player.transform.position + offset;
    }
}
