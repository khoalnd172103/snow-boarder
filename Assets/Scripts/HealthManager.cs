using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health = 3;
    public static int maxHealth = 3;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Awake()
    {
        UpdateHearts();
    }

    void Update()
    {
        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void IncreaseHealth(int amount)
    {
        int maxHealth = hearts.Length;
        if (health < maxHealth)
        {
            health = Mathf.Min(health + amount, maxHealth);
            UpdateHearts();
        }
    }
}
