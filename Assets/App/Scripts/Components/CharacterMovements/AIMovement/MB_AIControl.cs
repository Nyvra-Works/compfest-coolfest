using UnityEngine;

public class MB_AIControl : MB_CharacterControl
{
    public override Vector3 TargetDirection { get; set; }
    [SerializeField] private MB_TargetsFinderByLayer _targetFinder;
    private void Awake()
    {
    }
    void Update()
    {
        if (_targetFinder.Targets.Count > 0)
        {
            var target = _targetFinder.Targets[0];
            TargetDirection = (target.position - transform.position).normalized;
        }
        else
        {
            TargetDirection = Vector3.zero;
            Debug.LogWarning("No targets found. AI control is inactive.");
        }
    }


}