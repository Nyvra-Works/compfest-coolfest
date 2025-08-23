using UnityEngine;

public class MB_Facing : MonoBehaviour
{

    private Vector3 _lastDir = Vector3.down;

    public Vector3 LastDir => _lastDir;




    public (bool faceSide, bool faceForward, bool faceBackward) SetDirection(Vector3 dir)
    {
        if (dir != Vector3.zero)
        {
            _lastDir = dir;

            bool facingSide = Mathf.Abs(dir.x) > Mathf.Abs(dir.z);
            bool facingForward = dir.z > 0 && !facingSide;
            bool facingBackward = dir.z < 0 && !facingSide;

            // if (facingSide)
            //     _spriteRenderer.flipX = (dir.x < 0);

            return (facingSide, facingForward, facingBackward);
        }

        // Return the state from last known dir if input is zero
        bool lastSide = Mathf.Abs(_lastDir.x) > Mathf.Abs(_lastDir.z);
        bool lastForward = _lastDir.z > 0 && !lastSide;
        bool lastBackward = _lastDir.z < 0 && !lastSide;
        return (lastSide, lastForward, lastBackward);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 origin = transform.position;
        Vector3 flatDir = new Vector3(_lastDir.x, 0, _lastDir.z).normalized;

        if (flatDir == Vector3.zero)
            flatDir = Vector3.down;

        Gizmos.DrawLine(origin, origin + flatDir * 2f);
        Gizmos.DrawSphere(origin + flatDir * 2f, 0.1f);
    }
}
