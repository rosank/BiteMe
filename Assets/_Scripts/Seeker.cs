using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Seeker : MonoBehaviour {
    [SerializeField] private float maxSpeed;
    [SerializeField] private float aoe;
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

    public Vector3 Seek(Vector3 targetPosition, float aoe = 0) {
        var desired = targetPosition - rbody.position;
        if(aoe != 0f && desired.sqrMagnitude > aoe * aoe) {
            return Vector3.zero;
        }
        desired.Normalize();
        desired *= maxSpeed;
        var steer = desired - rbody.velocity;
        steer = Vector3.ClampMagnitude(steer, maxSpeed);
        return steer;
    }

    private static Vector3 Steer(Vector3 currentVelocity, float maxSpeed, Vector3 seekDirection) {
        seekDirection.Normalize();
        seekDirection *= maxSpeed;
        return Vector3.ClampMagnitude((seekDirection - currentVelocity), maxSpeed);
    }

    public static Vector3 Seek(Transform seeker, Transform target, Vector3 currentVelocity, float maxSpeed) {
        return Steer(currentVelocity, maxSpeed, target.position - seeker.position);
    }

    public static Vector3 Seperate(Transform me, Transform[] neighbours, float gap, Vector3 currentVelocity, float maxSpeed) {
        int count = 0;
        Vector3 sum = Vector3.zero;
        for(int i = 0; i < neighbours.Length; i++) {
            if(neighbours[i] == me) { continue; }
            float d = Vector3.Distance(me.position, neighbours[i].position);
            if(d > 0 && d < gap) {
                var diff = (me.position - neighbours[i].position).normalized;
                diff /= d;
                sum += diff;
                count += 1;
            }
        }
        if(count > 0) {
            sum /= count;
            return Steer(currentVelocity, maxSpeed, sum);
        }
        return Vector3.zero;
    }

    public void UpdateSeeker(Seeker[] seekers, float gap, Vector3 targerPosition) {
        var separate = Separate(seekers, gap);
        var seek = Seek(targerPosition, this.aoe);
        rbody.AddForce(separate, ForceMode.VelocityChange);
        rbody.AddForce(seek, ForceMode.VelocityChange);
    }
}
