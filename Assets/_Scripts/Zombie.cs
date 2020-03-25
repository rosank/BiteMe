using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zombie : MonoBehaviour {
    [SerializeField] private CController cController;
    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void _Update(Transform[] allZombies, Transform target, float zombieGap) {
        cController.Move(Seeker.Seek(transform, target, cController.Velocity, moveSpeed));
        //cController.Move(Seeker.Seperate(transform, allZombies, zombieGap, cController.Velocity, maxSpeed));
        var dir = (target.position - transform.position).normalized;
        transform.forward = dir;
    }
}
