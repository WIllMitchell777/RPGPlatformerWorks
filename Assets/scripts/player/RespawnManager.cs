using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager instance;
    private Vector3 respawnPosition;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void SetCheckpoint(Vector3 position)
    {
        respawnPosition = position;
        Debug.Log("Checkpoint saved at " + respawnPosition);
    }

    public void Respawn(GameObject player)
    {
        player.transform.position = respawnPosition;
    }
}
