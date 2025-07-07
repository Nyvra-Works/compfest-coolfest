using StateMachines.Enemy.States;
using UnityEngine;

public class MB_EnemyMovement : MB_CharacterMovement
{
    bool _overrideStopWalk = false;
    [Header("Enemy State Machine")]
    [SerializeField] MB_EnemyStateContext _enemyStateMachine;
    void OnEnable()
    {
        _enemyStateMachine.OnAttackingEnter += () => _overrideStopWalk = true;
        _enemyStateMachine.OnAttackingExit += () => _overrideStopWalk = false;
    }
    void OnDisable()
    {
        _enemyStateMachine.OnAttackingEnter -= () => _overrideStopWalk = true;
        _enemyStateMachine.OnAttackingExit -= () => _overrideStopWalk = false;
    }
    public override void Update()
    {

        if (!_overrideStopWalk)
        {
            _walkable.SetPosition(_characterControl.TargetDirection);
        }
        else
        {
            _walkable.SetPosition(Vector3.zero);
        }
        // Debug.Log($"Target Direction: {_characterControl.TargetDirection}");
    }
}