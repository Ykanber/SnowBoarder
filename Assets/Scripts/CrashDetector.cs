using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private ParticleSystem crashParticle;
    [SerializeField] private float delayTime = 1f;
    [SerializeField] private AudioClip crashsfx;

    bool crashed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(!crashed &&collision.tag == "Ground")
        {
            crashed = true;
            PlayerController temp = FindObjectOfType<PlayerController>();
            temp.DisableControls();
            crashParticle.Play();
            GetComponent<AudioSource>().PlayOneShot(crashsfx);
            Invoke(nameof(ReloadScene), delayTime);
        }
    }


    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
