using UnityEngine;

public class LegoCharacterController : MonoBehaviour
{
    public float speed = 2.0f; // Walking speed
    public float rotationSpeed = 700f; // Rotation speed
    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        // Detect key presses for movement direction
        if (Input.GetKey(KeyCode.UpArrow)) // Move forward
        {
            movement += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow)) // Move backward
        {
            movement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // Move left
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow)) // Move right
        {
            movement += Vector3.right;
        }

        // Normalize movement vector to keep consistent speed
        movement = movement.normalized;

        if (movement != Vector3.zero)
        {
            // Move the character in the direction specified by input
            rb.MovePosition(transform.position + movement * speed * Time.deltaTime);

            // Rotate the character smoothly to face the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Play the walking animation when moving
            animator.Play("Walk");
        }
        else
        {
            // Play the idle animation when no input is detected
            animator.Play("Rest");
        }
    }
}










