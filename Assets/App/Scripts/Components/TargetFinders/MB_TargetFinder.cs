using System.Collections.Generic;
using UnityEngine;

public abstract class MB_TargetFinder : MonoBehaviour
{
    public abstract List<Transform> Targets { get; set; }
    public abstract bool HasTargets();
}