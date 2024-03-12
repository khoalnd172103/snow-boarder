using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke(nameof(NextScene), loadDelay);
        }
    }

    void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //save data here
        FindObjectOfType<PlayerSaveData>().Save();
        if (currentSceneIndex == 3)
        {
            // WIN LOGIC HERE

            //maybe a win scene
        }
        else
        {

            SceneManager.LoadSceneAsync(4);
        }
    }
}
