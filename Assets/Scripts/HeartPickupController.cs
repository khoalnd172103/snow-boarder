using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    private readonly List<GameObject> hearts = new List<GameObject>();

    private void Start()
    {
        GameObject[] heartObjects = GameObject.FindGameObjectsWithTag("Heart");
        foreach (GameObject heart in heartObjects)
        {
            hearts.Add(heart);
        }

        Debug.Log("Heart count: " + hearts.Count);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            Debug.Log("Got heart");
            GameObject heartToDestroy = other.gameObject;
            if (hearts.Contains(heartToDestroy))
            {
                hearts.Remove(heartToDestroy);
                Destroy(heartToDestroy);
            }

            if (HealthManager.health < HealthManager.maxHealth)
            {
                HealthManager.health++;
                StartCoroutine(GetHeart());
            }
        }
    }

    IEnumerator GetHeart()
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }
}
