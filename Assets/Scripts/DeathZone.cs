using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [Header("Respawn Settings")]
    public Transform player1SpawnPoint;
    public Transform player2SpawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement2D player = other.GetComponent<PlayerMovement2D>();
        
        if (player != null)
        {
            if (player.playerId == PlayerMovement2D.PlayerId.Player1 && player1SpawnPoint != null)
            {
                player.Respawn(player1SpawnPoint.position);
            }
            else if (player.playerId == PlayerMovement2D.PlayerId.Player2 && player2SpawnPoint != null)
            {
                player.Respawn(player2SpawnPoint.position);
            }
        }
    }
}