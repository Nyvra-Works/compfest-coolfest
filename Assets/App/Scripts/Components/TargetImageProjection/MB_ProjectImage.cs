using UnityEngine;

public class MB_ProjectImage : MonoBehaviour
{
    [SerializeField] Sprite _sprite;
    [SerializeField] LayerMask _projectionSurfaceLayerMask;
    [SerializeField] FloatReference _projectionSize = new FloatReference(1f);
    [SerializeField] FloatReference _maxProjectionDistance = new FloatReference(10f);
    [SerializeField] Vector3 _heading = Vector3.down;

    GameObject _projectedImage;

    private void Start()
    {
        if (_sprite == null)
        {
            Debug.LogError("Sprite is not assigned in MB_ProjectImage.");
            return;
        }

    }
    void Update()
    {
    }

    void OnEnable()
    {
        ProjectImage(transform.position);
    }
    void OnDestroy()
    {
        ClearProjectedImage();
    }

    public void ProjectImage(Vector3 position)
    {
        if (_sprite == null)
        {
            Debug.LogError("Sprite is not assigned in MB_ProjectImage.");
            return;
        }

        if (_projectionSurfaceLayerMask == 0)
        {
            Debug.LogError("Projection surface layer mask is not set in MB_ProjectImage.");
            return;
        }

        if (_projectedImage != null)
        {
            ClearProjectedImage();
        }
        RaycastHit hit;
        if (Physics.Raycast(position, _heading, out hit, _maxProjectionDistance.Value, _projectionSurfaceLayerMask))
        {
            GameObject _projectedImage = new GameObject("ProjectedImage");
            _projectedImage.transform.localScale = new Vector3(_projectionSize.Value, _projectionSize.Value, 1f);
            _projectedImage.transform.SetParent(transform);
            SpriteRenderer spriteRenderer = _projectedImage.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = _sprite;
            _projectedImage.transform.position = hit.point + hit.normal * 0.5f;
            _projectedImage.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
    }
    public void ClearProjectedImage()
    {
        if (_projectedImage != null)
        {
            Destroy(_projectedImage);
            _projectedImage = null;
        }
    }
}