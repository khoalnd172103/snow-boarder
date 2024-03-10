using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShieldManager shieldManager = other.GetComponent<ShieldManager>(); 
            if (shieldManager != null) 
            {
                shieldManager.ActivateShield(); 
            }
        }
    }
}
