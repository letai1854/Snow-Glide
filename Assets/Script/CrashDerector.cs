using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDerector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrash = false;
    void OnTriggerEnter2D(Collider2D other )
    {
        if (other.tag == "Ground" && !hasCrash)
        {
            hasCrash = true;
            FindObjectOfType<PlayerContronler>().DisableCanMove();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadSence", loadDelay);

        }
    }
    void ReloadSence()
    {
        SceneManager.LoadScene(0);
    }
}
