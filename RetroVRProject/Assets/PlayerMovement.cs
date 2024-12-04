using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f; // Speed of player movement
    public float rotationSpeed = 10f; // Speed of rotation smoothing
    private Rigidbody rb;

    private Vector3 movementInput; // Stores the movement input from the player
    private Quaternion targetRotation; // Stores the target rotation for the player

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevent physics from modifying rotation
    }

    void Update()
    {
        // Get input for movement (WASD or arrow keys)
        float horizontal = Input.GetAxisRaw("Horizontal"); // Left (-1) and Right (+1)
        float vertical = Input.GetAxisRaw("Vertical"); // Up (+1) and Down (-1)

        // Combine inputs into a movement vector
        movementInput = new Vector3(horizontal, 0, vertical).normalized;

        // If there is movement, calculate the target rotation
        if (movementInput != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(movementInput); // Face the movement direction
        }
    }

    void FixedUpdate()
    {
        // Apply movement to the Rigidbody
        rb.linearVelocity = movementInput * playerSpeed + new Vector3(0, rb.linearVelocity.y, 0); // Preserve vertical velocity (e.g., for jumping)

        // Smoothly rotate the player towards the target direction
        if (movementInput != Vector3.zero)
        {
            rb.rotation = Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

}
