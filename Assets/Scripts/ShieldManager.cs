using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public bool hasShield = false;
    public GameObject shieldObject;
    public float shieldDuration = 5f;

    public delegate void ShieldActivated();
    public static event ShieldActivated OnShieldActivated;

    public delegate void ShieldDeactivated();
    public static event ShieldDeactivated OnShieldDeactivated; // New event for shield deactivation

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

        if (OnShieldActivated != null)
        {
            OnShieldActivated();
        }
    }

    public void DeactivateShield()
    {
        hasShield = false;
        shieldObject.SetActive(false);
        Debug.Log("Shield deactivate");

        if (OnShieldDeactivated != null)
        {
            OnShieldDeactivated(); // Invoke the event when the shield is deactivated
        }
    }
}
