
using UnityEngine;
/// <summary>
/// Interface for game objects that can set their own position based on a direction
/// </summary>
/// <remarks>
/// <strong>locomotory</strong> adj. : capable of moving independently from place to place
/// </remarks>
public interface ILocomotory
{
    void SetPosition(Vector3 direction);
}