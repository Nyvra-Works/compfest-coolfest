using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MB_CollisionTargetFinderByLayer : MB_TargetFinder
{

    public override List<Transform> Targets
    {
        get => _targets?.OrderBy(t => Vector3.Distance(transform.position, t.position))
            .Select(t => t)
            .ToList();
        set => _targets = value;
    }
    public override bool HasTargets() => _targets != null && _targets.Count > 0;
    private List<Transform> _targets = new List<Transform>();

    [SerializeField] private LayerMask _targetLayer;


    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"OnCollisionEnter: {other.gameObject.name} in layer {LayerMask.LayerToName(other.gameObject.layer)}");
        if (IsInTargetLayer(other.gameObject.layer) && !_targets.Contains(other.transform))
        {
            _targets.Add(other.transform);
        }
        // Debug.Log("First Target's position: " + (Targets.Count > 0 ? Targets[0].position.ToString() : "No targets found"));
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log($"OnCollisionExit: {other.gameObject.name} in layer {LayerMask.LayerToName(other.gameObject.layer)}");
        if (_targets.Contains(other.transform))
        {
            _targets.Remove(other.transform);
        }
    }
    private bool IsInTargetLayer(int layer)
    {
        return (_targetLayer.value & (1 << layer)) != 0;
    }
}