using UnityEngine;

public class MB_TelekineticActor : MonoBehaviour
{
    [SerializeField] Vector3 _liftingPosition;
    [SerializeField] MB_TargetsFinderByLayer _teleliftableDetector;
    MB_TeleliftableItem _teleliftableItem;
    [SerializeField] MB_CombatInput _combatInput;
    [SerializeField] MB_Facing _facing;
    [SerializeField] SO_ThrowAim _throwAim;
    [SerializeField] SO_AimMarker _aimMarker;
    void OnEnable()
    {
        _combatInput.SpecialAttack2Event += AssignTeleliftableItem;
    }
    void OnDisable()
    {
        _combatInput.SpecialAttack2Event -= AssignTeleliftableItem;
    }
    void AssignTeleliftableItem()
    {
        if (_teleliftableItem != null)
        {
            Throw();
            return;
        }
        foreach (var target in _teleliftableDetector.Targets)
        {
            var item = target.GetComponent<MB_TeleliftableItem>();
            if (item != null)
            {
                _teleliftableItem = item;
                break;
            }
        }
    }
    void Lift()
    {
        var position = this.transform.position + _liftingPosition;
        _teleliftableItem.UpdatePosition(position);
    }
    void Throw()
    {
        // _teleliftableItem.Throw(_facing.LastDir);
        var target = _throwAim.GetBestTarget(_facing.LastDir, transform.position);
        if (target == null)
        {
            _teleliftableItem.Throw(_facing.LastDir);
        }
        else
        {
            _teleliftableItem.Throw(target.transform.position);
        }
        _teleliftableItem = null;
    }
    void Update()
    {
        var target = _throwAim.GetBestTarget(_facing.LastDir, transform.position);
        if (target != null && _teleliftableItem != null)
        {
            _aimMarker.RenderMarker(target != null ? target.transform.position : Vector3.zero);
        }
        else
        {
            _aimMarker.RenderMarker(Vector3.zero);
        }
    }
    void FixedUpdate()
    {
        if (_teleliftableItem != null)
        {
            Lift();
        }
    }

}