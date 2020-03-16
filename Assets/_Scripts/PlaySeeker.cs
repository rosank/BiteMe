using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlaySeeker : MonoBehaviour
{
    [SerializeField] private float maxSpeed;

    private Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    public Vector3 Separate(PlaySeeker[] playSeekers, float gap)
    {
        int count = 0;
        Vector3 sum = Vector3.zero;
        for (int i = 0; i < playSeekers.Length; i++)
        {
            if (playSeekers[i] == this) { continue; }
            float d = Vector3.Distance(rbody.position, playSeekers[i].rbody.position);
            if (d > 0 && d < gap)
            {
                var diff = (rbody.position - playSeekers[i].rbody.position).normalized;
                diff /= d;
                sum += diff;
                count += 1;
            }
        }
        if (count > 0)
        {
            sum /= count;
            sum.Normalize();
            sum *= maxSpeed;
            var steer = sum - rbody.velocity;
            steer = Vector3.ClampMagnitude(steer, maxSpeed);
            return steer;
        }
        return Vector3.zero;
    }

    public Vector3 PlaySeek(Vector3 targetPosition)
    {
        var desired = targetPosition - rbody.position;
        desired.Normalize();
        desired *= maxSpeed;
        var steer = desired - rbody.velocity;
        steer = Vector3.ClampMagnitude(steer, maxSpeed);
        return steer;
    }

    public void UpdateplaySeeker(PlaySeeker[] playSeekers, float gap, Vector3 targerPosition)
    {
        var separate = Separate(playSeekers, gap);
        var playSeek = PlaySeek(targerPosition);
        rbody.AddForce(separate, ForceMode.VelocityChange);
        rbody.AddForce(playSeek, ForceMode.VelocityChange);
    }
}
