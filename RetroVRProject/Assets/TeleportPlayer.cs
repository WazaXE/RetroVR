using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform teleportDestination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (teleportDestination != null)
            {
                other.transform.position = teleportDestination.position;
                Debug.Log($"Player teleported to {teleportDestination.position}");
            }else
            {
                Debug.LogWarning("Teleport destination is not set!");
            }
        }
    }
}
