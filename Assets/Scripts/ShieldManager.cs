using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public bool hasShield = false;
    public GameObject shieldObject;
    public float shieldDuration = 5f;

    private void Update()
    {
        if (hasShield)
        {
            shieldDuration -= Time.deltaTime;
            if (shieldDuration <= 0)
            {
                DeactivateShield();
            }
        }
    }

    public void ActivateShield()
    {
        hasShield = true;
        shieldObject.SetActive(true);
        Debug.Log("Shield activate");
    }

    public void DeactivateShield()
    {
        hasShield = false;
        shieldObject.SetActive(false);
        Debug.Log("Shield deactivate");
    }
}
