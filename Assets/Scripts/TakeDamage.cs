using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeDamage : MonoBehaviour
{
    private readonly List<GameObject> enemies = new();

    private void Start()
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemyObjects)
        {
            enemies.Add(enemy);
        }

        Debug.Log("Enemy: " + enemies.Count);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy");
            GameObject enemyToDestroy = collision.gameObject;
            if (enemies.Contains(enemyToDestroy))
            {
                enemies.Remove(enemyToDestroy);
                Destroy(enemyToDestroy);
            }

            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                Debug.Log("Game over");
                gameObject.SetActive(false);
                Invoke(nameof(ReloadScene), 0.5f);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }
}
