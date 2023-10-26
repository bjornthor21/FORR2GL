using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Animator og Rigidbody til a� me�h�ndla physics og animations.
    private Rigidbody playerRb;
    private Animator playerAnim;

    // Particle effect sem s�nir �egar player snertir umhverfi�.
    public ParticleSystem explosionParticle; // sprenging sem kemur �egar Player klessir � obstacle
    public ParticleSystem dirtParticle;      // mold sem Player sparkar upp �egar hann hleypur

    // AudioSource fyrir sound effects
    private AudioSource playerAudio;
    public AudioClip jumpSound;     // spilar �egar Player stekkur
    public AudioClip crashSound;   // spilar �egar Player klessir � obstacle

    // breytur sem sj� um hoppkraft og gravity
    public float jumpForce = 10;      // hopp kraftur players
    public float gravityModifier;     // breytir Gravity

    // bools sem segir til um hvort Player er � lofti (isOnGround) og hvort Player rekst � Obstacle.
    public bool isOnGround = true;    
    public bool gameOver = false;

    void Start()
    {
        // setur Rigidbody, Animator og AudioSource components � vi�eigandi breytur.
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        // breytir gravity leiksins
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        // ef �tt er � space, �� ert � j�r�inni og �� hefur ekki rekist � neinn obstacle.
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            // player hoppar
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // �egar player hoppar �� er hann ekki lengur � j�r�inni svo vi� breytum bool
            isOnGround = false;
            // Hefur hopp animation.
            playerAnim.SetTrigger("Jump_trig");
            // stoppa dirtParticle effect
            dirtParticle.Stop();
            // spilar hopp hlj��i�
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    // OnCollisionEnter er kalla� �egar Rigidbody Player snertir anna� Rigidbody e�a collider
    private void OnCollisionEnter(Collision collision)
    {
        // athugar me� hvort Player er a� snerta j�r�ina
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            // spilar dirtParticle effect.
            dirtParticle.Play();
        }
        // athugar hvort Player s� a� snerta Obstacle
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
