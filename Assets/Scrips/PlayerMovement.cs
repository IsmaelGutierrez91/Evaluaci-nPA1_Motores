using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [Header("PlayerPreferences")]
    Rigidbody _componentRigidbody;
    [SerializeField] float playerSpeed;
    [SerializeField] float playerJumpStrength;
    private float horizontalX;
    private float horizontalZ;
    bool canJump = false;
    public bool isThisThePrincipal = false;
    [Header("RayCastPreferences")]
    [SerializeField] Transform originPoint;
    [SerializeField] float rayCastLength;
    [SerializeField] LayerMask layerMask;
    public Color inCollision = Color.white;
    public Color outCollision = Color.white;

    private void Awake()
    {
        _componentRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (isThisThePrincipal == true)
        {
            _componentRigidbody.linearVelocity = new Vector3(horizontalX * playerSpeed, _componentRigidbody.linearVelocity.y, horizontalZ * playerSpeed);
            RaycastHit hit;
            if (Physics.Raycast(originPoint.position, Vector3.down, out hit, rayCastLength, layerMask))
            {
                Debug.DrawRay(originPoint.position, Vector3.down * hit.distance, inCollision);
                canJump = true;
            }
            else
            {
                Debug.DrawRay(originPoint.position, Vector3.down * rayCastLength, outCollision);
                canJump = false;
            }
        }
    }
    public void OnMovementX(InputAction.CallbackContext context)
    {
        horizontalX = context.ReadValue<float>();
    }
    public void OnMovementZ(InputAction.CallbackContext context)
    {
        horizontalZ = context.ReadValue<float>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (canJump == true)
        {
            _componentRigidbody.AddForce(Vector2.up * playerJumpStrength, ForceMode.Impulse);
        }
    }
}
