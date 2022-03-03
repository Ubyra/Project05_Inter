using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystems : PlayerStateMachine
{
    [Header("Player Atributes")]
    public Rigidbody rb;

    [Header("Player Movement")]
    public float playerVelocity;
    public float turnSmoothTime = 0.1f;
    public Vector3 direction;
    private Vector3 inputDirection;
    private float turnSmoothVelocity;

    private void Start()
    {
        SetState(new PlayerStart(this));
        inputDirection = Vector3.zero;
    }

    private void Update()
    {
        MovementCheck();
    }

    private void MovementCheck()
    {
        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.z = Input.GetAxisRaw("Vertical");
        inputDirection.Normalize();

        var cam = Camera.main;
        var foward = cam.transform.forward;
        var right = cam.transform.right;

        var parentTransform = gameObject.GetComponentInParent<Transform>();

        foward.y = 0;
        right.y = 0f;
        foward.Normalize();
        right.Normalize();

        direction = (foward * inputDirection.z + right * inputDirection.x).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Deg2Rad + cam.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(parentTransform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            parentTransform.rotation = Quaternion.Euler(0f, angle, 0f);

            State.Move();
        }
        else if (inputDirection.magnitude < 0.1f)
        {
            State.Stop();
        }
    }
}