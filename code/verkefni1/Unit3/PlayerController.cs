using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Animator og Rigidbody til að meðhöndla physics og animations.
    private Rigidbody playerRb;
    private Animator playerAnim;

    // Particle effect sem sýnir þegar player snertir umhverfið.
    public ParticleSystem explosionParticle; // sprenging sem kemur þegar Player klessir á obstacle
    public ParticleSystem dirtParticle;      // mold sem Player sparkar upp þegar hann hleypur

    // AudioSource fyrir sound effects
    private AudioSource playerAudio;
    public AudioClip jumpSound;     // spilar þegar Player stekkur
    public AudioClip crashSound;   // spilar þegar Player klessir á obstacle

    // breytur sem sjá um hoppkraft og gravity
    public float jumpForce = 10;      // hopp kraftur players
    public float gravityModifier;     // breytir Gravity

    // bools sem segir til um hvort Player er í lofti (isOnGround) og hvort Player rekst á Obstacle.
    public bool isOnGround = true;    
    public bool gameOver = false;

    void Start()
    {
        // setur Rigidbody, Animator og AudioSource components í viðeigandi breytur.
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        // breytir gravity leiksins
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        // ef ýtt er á space, þú ert á jörðinni og þú hefur ekki rekist á neinn obstacle.
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            // player hoppar
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // þegar player hoppar þá er hann ekki lengur á jörðinni svo við breytum bool
            isOnGround = false;
            // Hefur hopp animation.
            playerAnim.SetTrigger("Jump_trig");
            // stoppa dirtParticle effect
            dirtParticle.Stop();
            // spilar hopp hljóðið
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    // OnCollisionEnter er kallað þegar Rigidbody Player snertir annað Rigidbody eða collider
    private void OnCollisionEnter(Collision collision)
    {
        // athugar með hvort Player er að snerta jörðina
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            // spilar dirtParticle effect.
            dirtParticle.Play();
        }
        // athugar hvort Player sé að snerta Obstacle
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;

            Debug.Log("Game Over!");
            // spilar death animation.
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            // spilar explosionParticle effect
            explosionParticle.Play();
            // Stoppar dirt particle effect.
            dirtParticle.Stop();
            // spilar crash sound effect.
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
