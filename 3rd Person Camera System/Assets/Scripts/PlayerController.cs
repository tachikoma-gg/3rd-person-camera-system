using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float movementSpeed;

    private CharacterController characterController;
    private float currentAngle = 0;

    private Vector3 input;
    private Quaternion currentRotation;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        RotatePlayer();
        MovePlayer();
    }

    void RotatePlayer()
    {
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        input = input.magnitude > 1 ? input.normalized : input;

        float targetAngle = Mathf.Atan2(input.x, input.z) * Mathf.Rad2Deg;
        currentAngle = targetAngle + (currentAngle - targetAngle) * Mathf.Pow(rotationSpeed, Time.deltaTime);

        currentRotation = Quaternion.Euler(0, currentAngle, 0);

        transform.rotation = currentRotation;

        // fix negative angles issue.
    }

    void MovePlayer()
    {
        characterController.Move(currentRotation * Vector3.forward * input.magnitude * movementSpeed * Time.deltaTime);

        // lerp speed?
    }
}
