using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float verticalInput;
    public float horizontalInput;
    public float speed = 10.0f;
    public int score = 0;
    
    public AudioClip blipSound; 
    public AudioClip boomSound;
    private AudioSource playerAudio;

    public ParticleSystem goodParticle;
    public ParticleSystem badParticle;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    

    // Update is called once per frame
    void Update() 
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // if player collides with green ball, fireworks
        if (other.gameObject.CompareTag("Good"))
        {
            goodParticle.Play();
            playerAudio.PlayOneShot(blipSound, 1.0f);
            Destroy(other.gameObject);
        } 

        // if player collides with red ball, boom
        else if (other.gameObject.CompareTag("Bad"))
        {
            badParticle.Play();
            playerAudio.PlayOneShot(boomSound, 1.0f);
            Destroy(other.gameObject);

        }

    }
}