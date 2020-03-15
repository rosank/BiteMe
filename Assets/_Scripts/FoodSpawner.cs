using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {
    [SerializeField] private GameObject[] foodItems;
    [SerializeField] private float maxRadius;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        for(int i = 0; i < foodItems.Length; i++) {
            if(!foodItems[i].activeSelf) {
                var pos = RandomPosition();
                pos.y = 0.5f;
                foodItems[i].transform.position = pos;
                foodItems[i].SetActive(true);
            }
        }
    }

    Vector3 RandomPosition() {
        var cx = player.position.x;
        var cy = player.position.y;
        var angle = Random.Range(0, 360) * Mathf.Deg2Rad;
        var nx = Mathf.Clamp(cx + Mathf.Cos(angle) * maxRadius, -4f, 4f);
        var ny = Mathf.Clamp(cy + Mathf.Sin(angle) * maxRadius, -10f, 10f);
        return new Vector3(nx, 0f, ny);
    }
}
