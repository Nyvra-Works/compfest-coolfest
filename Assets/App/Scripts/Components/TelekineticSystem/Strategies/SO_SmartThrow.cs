using UnityEngine;

[CreateAssetMenu(fileName = "SO_SmartThrow", menuName = "Scriptable Objects/Throw/SO_SmartThrow", order = 0)]
public class SO_SmartThrow : SO_Throw
{
    [SerializeField] private float _arcAngle = 45f;
    public override void Execute(Vector3 targetPosition, Vector3 myPosition, Rigidbody rigidbody)
    {
        // rigidbody.linearVelocity = BallisticVelocity(targetPosition, myPosition, _arcAngle);
        rigidbody.linearVelocity = CalculateLaunchVelocity(myPosition, targetPosition, _arcAngle);
    }
    Vector3 BallisticVelocity(Vector3 target, Vector3 origin, float angle)
    {
        Vector3 dir = target - origin;      // arah target
        float h = dir.y;                    // beda ketinggian
        dir.y = 0;                          // buang Y → dapat jarak horizontal

        float dist = dir.magnitude;
        float g = Physics.gravity.magnitude;
        float rad = angle * Mathf.Deg2Rad;

        dir.y = dist * Mathf.Tan(rad);      // arah lempar (dengan tan θ)
        dist += h / Mathf.Tan(rad);

        float velocity = Mathf.Sqrt(dist * g / Mathf.Sin(2 * rad));

        return velocity * dir.normalized;
    }
    public static Vector3 CalculateLaunchVelocity(Vector3 start, Vector3 target, float angleDeg)
    {
        float g = Mathf.Abs(Physics.gravity.y);

        Vector3 planarTarget = new Vector3(target.x, 0, target.z);
        Vector3 planarPosition = new Vector3(start.x, 0, start.z);

        float distance = Vector3.Distance(planarTarget, planarPosition); // horizontal distance
        float height = target.y - start.y; // vertical offset
        float angle = angleDeg * Mathf.Deg2Rad;

        float cosAngle = Mathf.Cos(angle);
        float sinAngle = Mathf.Sin(angle);

        // Hitung kecepatan awal (v0)
        float v0Sq = (g * distance * distance) /
                     (2f * cosAngle * cosAngle * (distance * Mathf.Tan(angle) - height));

        if (v0Sq <= 0f)
        {
            // Tidak ada solusi real → sudut terlalu kecil/tinggi untuk target ini
            return Vector3.zero;
        }

        float v0 = Mathf.Sqrt(v0Sq);

        // Arah horizontal
        Vector3 dir = (planarTarget - planarPosition).normalized;

        // Komponen velocity
        Vector3 velocity = dir * v0 * cosAngle;
        velocity.y = v0 * sinAngle;

        return velocity;
    }



}