using UnityEngine;

public class AnimationController : MonoBehaviour {
    [SerializeField] private Rigidbody targetRigidBody;
    [SerializeField] private Animator targetAnimController;
    
    // Start is called before the first frame update
    void Start() {
           
    }

    // Update is called once per frame
    void Update() {
        targetAnimController.SetFloat("speed", targetRigidBody.velocity.sqrMagnitude > 0 ? 1 : 0f);
    }
}
