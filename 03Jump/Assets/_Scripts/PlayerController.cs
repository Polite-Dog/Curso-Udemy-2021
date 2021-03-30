using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    //Movement
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityMultiplier;
    private bool isOnGround = true;

    //Game Over
    private bool _gameOver;
    public bool GameOver {get => _gameOver;}

    //Anims
    private Animator _animator;
    private const string speed_F = "Speed_f";
    private const string jumpTrig = "Jump_trig";
    private const string ground = "Ground";
    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE_INT = "DeathType_int"; 


    private float speedForward = 1;
    private bool onGround = true;
    private bool deathB;
    private int deathtypeInt;

    //Particles

    public ParticleSystem explosion;
    public ParticleSystem runTrail;

    //SFX

    public AudioClip jump, crash;
    public AudioSource _audioSource;
    [Range(0, 1)]
    public float sfxVolume;

   // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = gravityMultiplier*new Vector3(0, -9.81f, 0);

        _animator = GetComponent<Animator>();
        _animator.SetFloat(speed_F, speedForward);
        _animator.SetBool(ground, onGround);
        _animator.SetBool(DEATH_B, deathB);
        _animator.SetInteger(DEATH_TYPE_INT, deathtypeInt);

        _audioSource = GetComponent<AudioSource>();
        
       

    }

    // Update is called once per frame
    void Update()
    {
        speedForward += Time.deltaTime / 100;
        _animator.SetFloat(speed_F, speedForward);

        _animator.SetBool(ground, onGround);
   
        if(Input.GetKeyDown(KeyCode.Space)&& isOnGround && !_gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //F = m*a
            isOnGround = false;
            _animator.SetTrigger(jumpTrig);
            onGround = false;

            runTrail.Stop();

            _audioSource.PlayOneShot(jump, sfxVolume);
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (!_gameOver)
            {
                runTrail.Play();
            }
            isOnGround = true;
            onGround = true;
            
            


           
        }else if(other.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            explosion.Play();
            
            _animator.SetBool(DEATH_B, _gameOver);
            _animator.SetInteger(DEATH_TYPE_INT, Random.Range(1, 3));
            _audioSource.PlayOneShot(crash, sfxVolume);

            runTrail.Stop();


            Invoke("RestartGame", 2.0f);
        }
            
             
    }
    private void RestartGame()
    {
        speedForward = 1;
        SceneManager.LoadSceneAsync("Prototype 3");
    }
}
