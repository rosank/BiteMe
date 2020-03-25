using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CController : MonoBehaviour {

    private CharacterController controller;
    public Vector3 Velocity {
        get => controller.velocity;
    }
    // Start is called before the first frame update
    void Start() {
        controller = GetComponent<CharacterController>();
    }

    public void Move(Vector3 velocity) {
        controller.SimpleMove(velocity);
    }

    public void Turn(Vector3 angularVelocity) {
        transform.Rotate(angularVelocity);
    }
}
