using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerController : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private Seeker[] seekers;
    [SerializeField, Range(1, 10)] private float sepration;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {
        for(int i = 0; i < seekers.Length; i++) {
             seekers[i].UpdateSeeker(seekers, sepration, target.position);
        }
    }
}
