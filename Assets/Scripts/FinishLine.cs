using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float delayTime = 0.5f;
    [SerializeField] private ParticleSystem finishEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke(nameof(ReloadScene), delayTime);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
