using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Transform orientation;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    LayerMask ground;
    [SerializeField]
    float groundDrag;
    [SerializeField]
    float airDrag;
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float airMultiplier;
    [SerializeField]
    float jumpForce;

    const float MOVEMENT_MULTIPLIER = 10f;
    const float GROUND_DISTANCE = 0.4f;

    RaycastHit slopeHit;
    Rigidbody rb;
    float playerHeight;
    float xMovement;
    float zMovement;
    Vector3 moveDirection;
    Vector3 slopeMoveDirection;
    bool pressingJump;

    bool OnSlope
    {
        get
        {
            if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2f + 0.5f, ground))
            {
                return slopeHit.normal != Vector3.up;
            }
            return false;
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerHeight = GetComponent<CapsuleCollider>().height;
        rb.freezeRotation = true;
    }

    void Update()
    {
        xMovement = Input.GetAxisRaw("Horizontal");
        zMovement = Input.GetAxisRaw("Vertical");
        pressingJump = Input.GetAxisRaw("Jump") > 0f;

        moveDirection = (orientation.forward * zMovement + orientation.right * xMovement).normalized;
        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);
    }

    void FixedUpdate()
    {
        bool isGrounded = Physics.CheckSphere(groundCheck.position, GROUND_DISTANCE, ground);
        if (isGrounded)
        {
            rb.linearDamping = groundDrag;
            if (OnSlope)
            {
                rb.AddForce(slopeMoveDirection * (movementSpeed * MOVEMENT_MULTIPLIER), ForceMode.Acceleration);
            }
            else
            {
                rb.AddForce(moveDirection * (movementSpeed * MOVEMENT_MULTIPLIER), ForceMode.Acceleration);
            }
            if (isGrounded)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }
        else
        {
            rb.linearDamping = airDrag;
            rb.AddForce(moveDirection * (movementSpeed * MOVEMENT_MULTIPLIER * airMultiplier), ForceMode.Acceleration);
        }
    }
}
