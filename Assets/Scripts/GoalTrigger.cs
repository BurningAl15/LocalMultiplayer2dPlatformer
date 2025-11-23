using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    [Header("Goal Settings")]
    public PlayerMovement2D.PlayerId targetPlayer;
    public ParticleSystem confetiParticles;
    
    [Header("Confeti Settings")]
    public float confetiInterval = 3f;
    public float shakeIntensity = 2f;
    public float shakeDuration = 0.5f;

    private bool goalReached = false;
    private static bool player1GoalReached = false;
    private static bool player2GoalReached = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (goalReached) return;

        PlayerMovement2D player = other.GetComponent<PlayerMovement2D>();
        
        if (player != null && player.playerId == targetPlayer)
        {
            goalReached = true;
            
            if (targetPlayer == PlayerMovement2D.PlayerId.Player1)
            {
                player1GoalReached = true;
            }
            else
            {
                player2GoalReached = true;
            }

            player.DisableMovement();

            TriggerCameraShake();

            if (confetiParticles != null)
            {
                StartCoroutine(ConfetiExplosionRoutine());
            }

            CheckBothPlayersReached();
        }
    }

    private void TriggerCameraShake()
    {
        if (CameraShake.Instance != null)
        {
            if (targetPlayer == PlayerMovement2D.PlayerId.Player1)
            {
                CameraShake.Instance.ShakeCamera_p1(shakeIntensity, shakeDuration);
            }
            else
            {
                CameraShake.Instance.ShakeCamera_p2(shakeIntensity, shakeDuration);
            }
        }
    }

    private IEnumerator ConfetiExplosionRoutine()
    {
        while (true)
        {
            if (confetiParticles != null)
            {
                confetiParticles.Play();
            }
            
            yield return new WaitForSeconds(confetiInterval);
        }
    }

    private void CheckBothPlayersReached()
    {
        if (player1GoalReached && player2GoalReached)
        {
            StartCoroutine(ReloadSceneAfterDelay(2f));
        }
    }

    private IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        player1GoalReached = false;
        player2GoalReached = false;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
