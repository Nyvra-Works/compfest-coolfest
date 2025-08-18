using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[CreateAssetMenu(fileName = "SO_ThrowAim", menuName = "Scriptable Objects/ThrowAim")]
public class SO_ThrowAim : ScriptableObject
{
    [Header("Finder")]
    [SerializeField] private float _maximumFinderRadius = 10f;
    [SerializeField] private LayerMask _targetMask; // layer target
    [SerializeField] private int _maxTargets = 10;

    [Header("Line of Sight")]
    [SerializeField] private LayerMask _obstacleMask; // obstacle yang bisa block

    [Header("Decision Weights\nAll shall add to 1")]
    [SerializeField] private float _distanceWeight = 1f;
    [SerializeField] private float _angleWeight = 1f;

    private Collider[] _candidates;
    private List<Collider> _visibleTargets = new List<Collider>();

    void Awake()
    {
        _candidates = new Collider[_maxTargets];
    }

    void Execute(Vector3 position)
    {
        // 1. Cari kandidat di radius
        int count = Physics.OverlapSphereNonAlloc(
            position,
            _maximumFinderRadius,
            _candidates,
            _targetMask
        );

        _visibleTargets.Clear();

        // 2. Filter dengan line of sight
        for (int i = 0; i < count; i++)
        {
            Collider target = _candidates[i];
            if (target == null) continue;

            Vector3 dir = (target.transform.position - position).normalized;
            float dist = Vector3.Distance(position, target.transform.position);

            if (Physics.Raycast(position, dir, out RaycastHit hit, dist, _obstacleMask | _targetMask))
            {
                if (hit.collider == target)
                {
                    _visibleTargets.Add(target);
                    Debug.DrawLine(position, target.transform.position, Color.green);
                }
                else
                {
                    Debug.DrawLine(position, hit.point, Color.red);
                }
            }
        }

        // sekarang _visibleTargets berisi semua target yang clear LOS
    }

    public List<Collider> GetVisibleTargets(Vector3 position)
    {
        Execute(position);
        return _visibleTargets;
    }
    public Collider GetBestTarget(Vector3 playerFacing, Vector3 position)
    {
        Execute(position);
        
        if (_visibleTargets.Count == 0) return null;

        Collider bestTarget = null;
        float bestScore = float.MaxValue;
        float maxDistance = _maximumFinderRadius;

        foreach (Collider target in _visibleTargets)
        {
            if (target == null) continue;

            // Hitung jarak ke target
            Vector3 toTarget = target.transform.position - position;
            float distance = toTarget.magnitude;

            // Hitung sudut antara arah player facing dan arah ke target
            float angle = Vector3.Angle(playerFacing, toTarget.normalized);

            // Normalisasi jarak (0-1, dimana 0 = sangat dekat, 1 = di batas radius)
            float normalizedDistance = distance / maxDistance;
            
            // Normalisasi sudut (0-1, dimana 0 = tepat di depan, 1 = 180 derajat)
            float normalizedAngle = angle / 180f;

            // Kombinasi skor (bobot jarak 0.4, bobot sudut 0.6 untuk lebih prioritaskan arah)
            float score = (_distanceWeight * normalizedDistance) + (_angleWeight * normalizedAngle);

            if (score < bestScore)
            {
                bestScore = score;
                bestTarget = target;
            }
        }

        return bestTarget;
    }

}
