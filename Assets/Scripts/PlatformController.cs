using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class PlatformController : MonoBehaviour
{
    [Header("References (assign in Inspector)")]
    [SerializeField]
    private Transform leftHand;
    [SerializeField]
    private Transform rightHand;

    [Header("Angle Mapping")]
    [SerializeField]
    private float maxTiltAngle = 12f;         // degrees
    [SerializeField]
    private float heightToAngleScale = 40f;   // degrees per meter
    [SerializeField]
    private float deadzoneMeters = 0.01f;     // meters
    [SerializeField]
    private float neutralOffset = 0f;         // calibrate if necessary in future

    [Header("Smoothing")]
    [SerializeField]
    private float smoothingTime = 0.12f;      // seconds for SmoothDamp

    float angleVelocity = 0f;
    float currentAngle = 0f;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Read inputs in Update
    float targetAngle = 0f;
    void Update()
    {
        if (leftHand == null || rightHand == null) return;

        float leftY = leftHand.position.y + neutralOffset;
        float rightY = rightHand.position.y;
        float diff = rightY - leftY;

        //Debug.Log($"Left hand pos: {leftY}");
        //Debug.Log($"Right hand pos: {rightY}");
        Debug.Log($"Tilt: {diff}");

        if (Mathf.Abs(diff) < deadzoneMeters) diff = 0f;

        float mapped = Mathf.Clamp(diff * heightToAngleScale, -maxTiltAngle, maxTiltAngle);
        targetAngle = mapped;
    }

    // Apply rotation in FixedUpdate
    void FixedUpdate()
    {
        // Smoothly move currentAngle towards targetAngle
        currentAngle = Mathf.SmoothDamp(currentAngle, targetAngle, ref angleVelocity, smoothingTime, Mathf.Infinity, Time.fixedDeltaTime);

        // Create desired rotation (assuming rotation axis is local X)
        Quaternion targetRot = Quaternion.Euler(0f, 0f, currentAngle);

        // Use MoveRotation for kinematic rigidbody to be physics-consistent
        rb.MoveRotation(transform.parent != null ? transform.parent.rotation * targetRot : targetRot);
        // Note: MoveRotation expects world rotation; we convert from local to world if needed.
    }

}
