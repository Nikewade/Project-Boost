using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float mainThrust = 1000;
    public float rotateThrust = 1000;
    public AudioClip thrust;
    public ParticleSystem mainBoosterParticle;
    public ParticleSystem leftParticle;
    public ParticleSystem rightParticle;

    Rigidbody rig;
    AudioSource audioSource;

    bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }


    private void FixedUpdate()
    {
        Rotate();
        Thrust();
    }

    void Thrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rig.AddRelativeForce((Vector3.up * mainThrust) * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(thrust);
            }
            if(!mainBoosterParticle.isPlaying)
            {
                mainBoosterParticle.Play();
            }
        }
        else
        {
            audioSource.Stop();
            mainBoosterParticle.Stop();
        }
    }

    void Rotate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            float h = Input.GetAxis("Horizontal") * rotateThrust * Time.deltaTime;
            rig.freezeRotation = true; // Freeze rotation so we can manually rotate
            transform.Rotate(0, 0, -h);
            rig.freezeRotation = false;
            if (!rightParticle.isPlaying)
            {
                rightParticle.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            float h = Input.GetAxis("Horizontal") * rotateThrust * Time.deltaTime;
            rig.freezeRotation = true; // Freeze rotation so we can manually rotate
            transform.Rotate(0, 0, -h);
            rig.freezeRotation = false;
            if(!leftParticle.isPlaying)
            {
                leftParticle.Play();
            }
        }
        else
        {
            rightParticle.Stop();
            leftParticle.Stop();
        }
    }


    public void stopParticles()
    {
        leftParticle.Stop();
        rightParticle.Stop();
        mainBoosterParticle.Stop();
    }
}
