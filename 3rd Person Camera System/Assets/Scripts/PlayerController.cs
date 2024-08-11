using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float movementSpeed;

    private Transform cameraTransform;
    private CharacterController characterController;
    private Animator playerAnimator;
    private float currentAngle = 0;

    private float gravity = -9.8f;

    private Vector3 input;
    private Vector3 velocity;

    private float playerCurrentSpeed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = FindObjectOfType<CameraController>().GetComponent<Transform>();
        playerAnimator = GetComponent<Animator>();
    }
    
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        velocity.y = (characterController.isGrounded && velocity.y <= 1) ? -2f : velocity.y + gravity * Time.deltaTime;

        if(input.magnitude > 0)
        MovePlayer();
    }

    void MovePlayer()
    {
        input = input.magnitude > 1 ? input.normalized : input;

        float inputAngle = Mathf.Atan2(input.x, input.z) * Mathf.Rad2Deg;
        float targetAngle = inputAngle + cameraTransform.eulerAngles.y;

        currentAngle = targetAngle + (currentAngle - targetAngle) * Mathf.Pow(rotationSpeed, Time.deltaTime);

        // fix jumping angles. Check guardians puzzle?
        transform.rotation = Quaternion.Euler(0, currentAngle, 0);

        playerCurrentSpeed = movementSpeed * input.magnitude;
        playerAnimator.SetFloat("speed", input.magnitude);

        Vector3 playerMovement = transform.rotation * Vector3.forward * playerCurrentSpeed;

        // lerp speed?
        velocity.x = playerMovement.x;
        velocity.z = playerMovement.z;

        characterController.Move(Time.deltaTime * velocity);
    }
}
