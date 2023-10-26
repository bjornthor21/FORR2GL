using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �essi skrifta s�r um a� b�a til n�tt obstacle fyrir framan player
public class SpawnManager : MonoBehaviour
{
    // skilgreini hva�a GameObject �g vil b�a til (Spawn)
    public GameObject obstaclePrefab;
    // skilgreini sta�setningu hvar obstacle � a� b�ast til
    private Vector3 spawnPos = new Vector3(35, 0, 0);
    // skilgreinir 2s delay � fyrsta skipti� sem hlutirnn er b�inn til og hve langt l��ur � milli.
    private float StartDelay = 2;
    private float RepeatRate = 2;
    // s�kir PlayerController skriptuna til a� geta nota� breytu �a�an
    private PlayerController playerControllerScript;


    void Start()
    {
        // finnur og s�kir player
        playerControllerScript = GameObject.Find("player").GetComponent<PlayerController>();
        // byrjar ferli� a� b�a til n�tt og n�tt obstacle me� vi�eigandi delay
        InvokeRepeating("spawnObstacle", StartDelay, RepeatRate);
    }

    void Update()
    {
        
    }

    void spawnObstacle ()
    {
        // ef gameOver er false (player er ekki b�inn a� rekast � obstacle)
        if(!playerControllerScript.gameOver)
        {
            // b�r til n�jan obstacle � vi�eigandi sta�setningu og sn�r r�tt
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
