using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject chrCamera;
    private PhotonView _PV; 
    public float moveSpeed = 15.0f;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private WalkSound _walkSound;
    private Rigidbody _rigidbody;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _PV = gameObject.GetComponent<PhotonView>();
        //Screen.lockCursor = true;
        chrCamera.transform.SetParent(gameObject.transform);
        chrCamera.transform.localPosition = new Vector3(0, 9, -16);
        _walkSound = GetComponent<WalkSound>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_PV.IsMine)
        {
            CameraRotation();
            Vector3 oldPosition = gameObject.transform.position;
            Vector3 vectorMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
            transform.Translate(vectorMovement.normalized * moveSpeed * Time.deltaTime);
            if (oldPosition != gameObject.transform.position)
            {
                _walkSound.PlayRandomSound();
            }
        }
    }
    
    
    

    public void CameraRotation()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        if (pitch<-45)
        {
            pitch = -45;
        }
        else if (pitch > 45)
        {
            pitch = 45;
        }
        
        transform.eulerAngles = new Vector3(pitch,yaw, 0.0f);
    }
}
