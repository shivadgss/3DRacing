using UnityEngine;

public class CarController : MonoBehaviour
{
    public float initialSpeed = 10f;       // Initial speed of the car
    public float acceleration = 1f;        // Rate of speed increase
    public float deceleration = 2f;        // Rate of speed decrease
    public float rotationSpeed = 100f;     // Rotation speed of the car
    public float maxSpeed = 30f;           // Maximum speed limit
    public AudioSource carAudioSource;     // Audio source for the car engine sound

    private Rigidbody carRigidbody;
    private float currentSpeed;
    private bool isAccelerating;

    public float CurrentSpeed => currentSpeed;
    public bool IsAccelerating => isAccelerating;

    private void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
        currentSpeed = initialSpeed;
        isAccelerating = false;
    }

    private void Update()
    {
        // Get input from the arrow keys or WASD
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector3 movement = transform.forward * moveVertical * currentSpeed * Time.deltaTime;

        // Apply the movement to the car
        carRigidbody.MovePosition(carRigidbody.position + movement);

        // Calculate the rotation vector
        float rotation = moveHorizontal * rotationSpeed * Time.deltaTime;

        // Apply the rotation to the car
        carRigidbody.MoveRotation(carRigidbody.rotation * Quaternion.Euler(0f, rotation, 0f));

        // Check if the car is accelerating
        isAccelerating = moveVertical != 0f;

        // Update the speed based on acceleration or deceleration
        if (isAccelerating)
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
        }
        else if (currentSpeed > initialSpeed)
        {
            currentSpeed -= deceleration;
            currentSpeed = Mathf.Max(currentSpeed, initialSpeed);
        }

        // Play audio when the car is moving
        if (isAccelerating)
        {
            if (!carAudioSource.isPlaying)
                carAudioSource.Play();
        }
        else
        {
            carAudioSource.Stop();
        }
    }
}
