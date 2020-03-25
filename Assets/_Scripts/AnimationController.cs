using UnityEngine;

public class AnimationController : MonoBehaviour {
    [SerializeField] private CController movementCtrl;
    [SerializeField] private Animator animationCtrl;
    

    // Update is called once per frame
    void FixedUpdate() {
        animationCtrl.SetFloat("speed", movementCtrl.Velocity.sqrMagnitude > 0 ? 1 : 0f);
    }
}
