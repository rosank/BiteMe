using UnityEngine;

public class LookAt : MonoBehaviour {
    public bool onlyIfInRange;
    public float lookupRange;
    public Transform target;



    void Update() {
        // Rotate the camera every frame so it keeps looking at the target
        // Same as above, but setting the worldUp parameter to Vector3.left in this example turns the camera on its side
        //transform.LookAt(target, Vector3.up);
        if(onlyIfInRange) {
            var dist = Vector3.Distance(transform.position, target.position);
            if(dist > lookupRange) {
                return;
            }
        }
        transform.LookAt(target);

    }
}
