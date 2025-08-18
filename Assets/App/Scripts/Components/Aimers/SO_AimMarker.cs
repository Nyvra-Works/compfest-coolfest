using UnityEngine;

[CreateAssetMenu(fileName = "SO_AimMarker", menuName = "Scriptable Objects/Aimers/SO_AimMarker", order = 0)]
public class SO_AimMarker : ScriptableObject
{
    [SerializeField] SpriteRenderer _markerPrefab;

    private Vector3 _lastPos;
    private SpriteRenderer _marker;
    public void RenderMarker(Vector3 aimWorldPos)
    {
        if (_marker == null)
        {
            _marker = Instantiate(_markerPrefab, aimWorldPos, Quaternion.identity);

        }
        if (_lastPos == aimWorldPos || aimWorldPos == null) 
        {
            return;
        }
        

        _marker.transform.position = aimWorldPos;
        _lastPos = aimWorldPos;
    }

}