using System;
using System.Collections.Generic;
using StateMachines.Player.States;
using UnityEngine;

public abstract class MB_AbstractContext<EState> : MonoBehaviour where EState : Enum
{
    // public abstract Dictionary<object, object> States { get; protected set; }
    // protected AbstractState<MB_AbstractContext<EState>> currentState;
    public abstract void TransitionToState(EState newState);
}