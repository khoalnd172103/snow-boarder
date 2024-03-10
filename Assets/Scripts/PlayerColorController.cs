using UnityEngine;

public class PlayerColorController : MonoBehaviour
{
    private SpriteRenderer playerRenderer;

    void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>();

        if (playerRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the player GameObject.");
        }
        else
        {
            playerRenderer.enabled = false;
            ShieldManager.OnShieldActivated += OnShieldActivated;
            ShieldManager.OnShieldDeactivated += OnShieldDeactivated;
        }
    }

    private void OnDestroy()
    {
        ShieldManager.OnShieldActivated -= OnShieldActivated;
        ShieldManager.OnShieldDeactivated -= OnShieldDeactivated;
    }

    void OnShieldActivated()
    {
        if (playerRenderer != null)
        {
            playerRenderer.enabled = true;
        }
    }

    void OnShieldDeactivated()
    {
        if (playerRenderer != null)
        {
            playerRenderer.enabled = false;
        }
    }
}
