using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZombieController : MonoBehaviour {
    [SerializeField] private Zombie[] zombies;
    [SerializeField] private Transform targetTransform;

    private Transform[] zombiesTransform;
    // Start is called before the first frame update
    void Start() {
        zombiesTransform = new Transform[zombies.Length];
        int index = 0;
        Array.ForEach(zombies, x => {
            zombiesTransform[index] = x.transform;
            index += 1;
        });
    }

    // Update is called once per frame
    void Update() {
        Array.ForEach(zombies, x => {
            x._Update(zombiesTransform, targetTransform, 2);
        });
    }
}
