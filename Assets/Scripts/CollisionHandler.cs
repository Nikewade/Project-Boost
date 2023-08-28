using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public AudioClip crash;
    public AudioClip finish;
    public ParticleSystem crashParticle;
    public ParticleSystem finishParticle;

    AudioSource audioSource;

    bool colliding = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(!this.enabled)
        {
            return;
        }

        if(!colliding)
        {
            switch (collision.gameObject.tag)
            {
                case "Friendly":
                    break;
                case "Finish":
                    Finish();
                    break;
                default:
                    Crash();
                    break;
            }
        }

    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void Crash()
    {
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticle.Play();
        GetComponent<Movement>().stopParticles();
        Invoke("ReloadScene", 1f);
        colliding = true;
    }

    void Finish()
    {
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(finish);
        finishParticle.Play();
        GetComponent<Movement>().stopParticles();
        Invoke("LoadNextScene", 1f);
        colliding = true;
    }
}
