using System.Collections;
using UnityEngine;

public class BallRespawner : MonoBehaviour
{
    [Header("Respawn Settings")]
    [Tooltip("Height below which the ball will respawn.")]
    public float respawnHeight = -0.5f;

    [Tooltip("Delay before respawning (seconds). Set 0 for instant.")]
    public float respawnDelay = 3.0f;

    private Rigidbody rb;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool isRespawning = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Store the exact starting position and rotation
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        // Check if the ball has fallen below the height threshold
        if (!isRespawning && transform.position.y < respawnHeight)
        {
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        isRespawning = true;

        // Wait for the delay
        if (respawnDelay > 0f)
            yield return new WaitForSeconds(respawnDelay);

        // Halt all physics motion
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Teleport to the starting location
        transform.SetPositionAndRotation(startPosition, startRotation);

        // Put the Rigidbody to sleep (ensures it is perfectly still)
        rb.Sleep();

        isRespawning = false;
    }
}
