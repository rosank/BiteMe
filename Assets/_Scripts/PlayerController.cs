using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private PlaySeeker[] players;
    [SerializeField, Range(1, 10)] private float sepration;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {
        for(int i = 0; i < players.Length; i++) {
             players[i].UpdateplaySeeker(players, sepration, target.position);
        }
    }
}
