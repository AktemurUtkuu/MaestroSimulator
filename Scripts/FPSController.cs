using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public Transform cameraTransform;
    public Animator animator;
    public float gravity = -9.81f;

    private CharacterController controller;
    private float rotationX = 0f;

    Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Mouse hareketi
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        
        // Yerçekimi
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Hareket girişi
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveInput = new Vector3(moveX, 0, moveZ);
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Animator için hareket kontrolü
        if (moveInput.magnitude > 0.1f)
        {
            animator.SetBool("isWalking", true);

            float direction = 0f;

            // Öncelik: özel kombinasyonlar
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                direction = -1f; // Sol
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                direction = 1f; // Sağ
            }
            // Tekil yön kontrolleri
            else if (Input.GetKey(KeyCode.W))
            {
                direction = 0f; // İleri
            }
            else if (Input.GetKey(KeyCode.S))
            {
                direction = 2f; // Geri
            }
            else if (Input.GetKey(KeyCode.A))
            {
                direction = -1f; // Sol
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction = 1f; // Sağ
            }

            animator.SetFloat("moveDirection", direction);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }


    }
}
