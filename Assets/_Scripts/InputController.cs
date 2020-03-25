using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    [SerializeField] private CController cController;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        cController.Move(transform.forward * moveSpeed * Input.GetAxis("Vertical"));
        cController.Turn(transform.up * turnSpeed  * Input.GetAxis("Horizontal"));
    }
}
