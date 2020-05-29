﻿using UnityEngine;
using Cinemachine;
using Photon.Pun;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private Transform _holder_ThirdPersonCameraTransform;
    [SerializeField] private PhotonView _photonView;
    public CinemachineFreeLook cinemachineFreeLook;
    public Transform mainCameraTransform;

    private const float speed = 6f;
    private const float turnSmoothTime = 0.0f;
    private float turnSmoothVelocity;

    private bool _IsLocalFlag;

    private void Start()
    {
        _IsLocalFlag = _photonView.IsMine;
        if (!_IsLocalFlag) enabled = false; //new idea. Is it have the right to live if satisfies the conditions?
        if (!_IsLocalFlag) return; //old idea
        cinemachineFreeLook.LookAt = _holder_ThirdPersonCameraTransform;
        cinemachineFreeLook.Follow = _holder_ThirdPersonCameraTransform;

    }
    private void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            // shitty but should work
            //Camera.main is shitty better use something that will inform about main camera that cannot be null
            // in example Game.MainCamera
            var camera = _IsLocalFlag ? mainCameraTransform : Camera.main.transform;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 movementDirection = Quaternion.Euler(0f, direction.y, 0f)*Vector3.forward;
            _capsuleCollider.transform.Translate(movementDirection.normalized * speed * Time.deltaTime);
            
        }
    }
}
