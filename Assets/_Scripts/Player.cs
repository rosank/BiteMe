using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float maxSpeed;

    private Rigidbody rbody;
    private Vector3 inputDirection;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        inputDirection = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        rbody.MovePosition(transform.position + inputDirection * maxSpeed * Time.fixedDeltaTime);
    }
}