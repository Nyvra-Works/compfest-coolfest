using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public interface ICharacterMovementControl
{
    Vector3 TargetDirection { get; }
    
}