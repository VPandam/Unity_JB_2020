using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    Rigidbody rigidbody;
    public bool moving = false;
    public float movementSpeed = 10f;
    public ParticleSystem runningParticles, explosion;

    public LayerMask groundMask;
    BoxCollider playerCollider;

    //Animation parameters
    const string SPEED_F = "Speed_f";
    const string DEATH_B = "Death_b";
    const string DEATHTYPE_INT = "DeathType_int";
    const string JUMP_TRIG = "Jump_trig";

    //Tags
    const string GROUND = "Ground";

    //Audio

    public AudioClip crash, jump;
    AudioSource playerAudioSource;



    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameMode.inGame)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetKey(KeyCode.D))
            {
                moving = true;
                animator.SetBool("MovingPalante", true);
                this.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

            }
            if (Input.GetKeyDown(KeyCode.D) && CheckOnTheGround())
            {
                runningParticles.Play();
            }
            if (Input.GetKeyUp(KeyCode.D))
            {

                animator.SetBool("MovingPalante", false);
                if (animator.GetFloat(SPEED_F) < 0.6f)
                {
                    runningParticles.Stop();
                }

            }

            if (Input.GetKey(KeyCode.A))
            {
                moving = true;
                this.transform.Translate(Vector3.forward * Time.deltaTime * -movementSpeed);
            }

            if (animator.GetFloat(SPEED_F) > 0.59 && animator.GetFloat(SPEED_F) < 0.61)
            {
                runningParticles.Play();
            }
        }


        Debug.DrawRay(this.transform.position, Vector3.down * 0.3f, Color.red);
    }


    private bool CheckOnTheGround()
    {
        if (Physics.Raycast(this.transform.position, Vector3.down, 0.3f, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }



        //Debug.Log(collision.gameObject.tag);
        //if (collision.gameObject.CompareTag("Ground"))
        //{

        //    onTheGround = true;

        //}


    }


    void Jump()
    {
        if (CheckOnTheGround())
        {
            animator.SetTrigger(JUMP_TRIG);
            playerAudioSource.PlayOneShot(jump, 0.2f);
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            runningParticles.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GROUND) && animator.GetFloat(SPEED_F) >= 0.6f)
        {
            runningParticles.Play();
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (GameManager.sharedInstance.currentGameState == GameMode.inGame)
            {
                playerAudioSource.PlayOneShot(crash, 1);
                Die();
            }


        }
    }

    void Die()
    {
        explosion.Play();
        GameManager.sharedInstance.currentGameState = GameMode.gameOver;
        moving = false;
        animator.SetFloat(SPEED_F, 0f);
        animator.SetInteger(DEATHTYPE_INT, 1);
        animator.SetBool(DEATH_B, true);



        runningParticles.Stop();
    }
}
