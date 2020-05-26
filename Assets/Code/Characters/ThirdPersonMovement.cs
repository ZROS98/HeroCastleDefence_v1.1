using UnityEngine;
using Cinemachine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private Transform _Holder_ThirdPersonCameraTransform;
    public CinemachineFreeLook cinemachineFreeLook;
    public Transform mainCameraTransform;

    private const float speed = 6f;
    private const float turnSmoothTime = 0.0f;
    private float turnSmoothVelocity;

    private void Start()
    {
        cinemachineFreeLook.LookAt = _Holder_ThirdPersonCameraTransform;
        cinemachineFreeLook.Follow = _Holder_ThirdPersonCameraTransform;
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCameraTransform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 movementDirection = Quaternion.Euler(0f, direction.y, 0f)*Vector3.forward;
            _capsuleCollider.transform.Translate(movementDirection.normalized * speed * Time.deltaTime);
        }
    }
}
