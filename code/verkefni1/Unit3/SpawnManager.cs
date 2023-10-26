using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// þessi skrifta sér um að búa til nýtt obstacle fyrir framan player
public class SpawnManager : MonoBehaviour
{
    // skilgreini hvaða GameObject ég vil búa til (Spawn)
    public GameObject obstaclePrefab;
    // skilgreini staðsetningu hvar obstacle á að búast til
    private Vector3 spawnPos = new Vector3(35, 0, 0);
    // skilgreinir 2s delay á fyrsta skiptið sem hlutirnn er búinn til og hve langt líður á milli.
    private float StartDelay = 2;
    private float RepeatRate = 2;
    // sækir PlayerController skriptuna til að geta notað breytu þaðan
    private PlayerController playerControllerScript;


    void Start()
    {
        // finnur og sækir player
        playerControllerScript = GameObject.Find("player").GetComponent<PlayerController>();
        // byrjar ferlið að búa til nýtt og nýtt obstacle með viðeigandi delay
        InvokeRepeating("spawnObstacle", StartDelay, RepeatRate);
    }

    void Update()
    {
        
    }

    void spawnObstacle ()
    {
        // ef gameOver er false (player er ekki búinn að rekast á obstacle)
        if(!playerControllerScript.gameOver)
        {
            // býr til nýjan obstacle í viðeigandi staðsetningu og snýr rétt
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
