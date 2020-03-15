using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Seeker : MonoBehaviour {
    [SerializeField] private float maxSpeed;

    private Rigidbody rbody;
    // Start is called before the first frame update
    void Start() {
        rbody = GetComponent<Rigidbody>();
    }

    public Vector3 Separate(Seeker[] seekers, float gap) {
        int count = 0;
        Vector3 sum = Vector3.zero;
        for(int i = 0; i < seekers.Length; i++) {
            if(seekers[i] == this) { continue; }
            float d = Vector3.Distance(rbody.position, seekers[i].rbody.position);
            if(d > 0 && d < gap) {
                var diff = (rbody.position - seekers[i].rbody.position).normalized;
                diff /= d;
                sum += diff;
                count += 1;
            }
        }
        if(count > 0) {
            sum /= count;
            sum.Normalize();
            sum *= maxSpeed;
            var steer = sum - rbody.velocity;
            steer = Vector3.ClampMagnitude(steer, maxSpeed);
            return steer;
        }
        return Vector3.zero;
    }

    public Vector3 Seek(Vector3 targetPosition) {
        var desired = targetPosition - rbody.position;
        desired.Normalize();
        desired *= maxSpeed;
        var steer = desired - rbody.velocity;
        steer = Vector3.ClampMagnitude(steer, maxSpeed);
        return steer;
    }

    public void UpdateSeeker(Seeker[] seekers, float gap, Vector3 targerPosition) {
        var separate = Separate(seekers, gap);
        var seek = Seek(targerPosition);
        rbody.AddForce(separate, ForceMode.VelocityChange);
        rbody.AddForce(seek, ForceMode.VelocityChange);
    }
}
