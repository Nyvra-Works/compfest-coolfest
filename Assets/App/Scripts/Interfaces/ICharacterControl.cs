using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public interface ICharacterControl
{
    Vector3 TargetDirection { get; }
}