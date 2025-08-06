using UnityEngine;

public class MB_PuzzleController : MonoBehaviour
{
    [SerializeField] private MB_WorldButton _inWorldButton;

    void OnEnable()
    {
        _inWorldButton.OnIsActiveTrue += SetMoveTrue;
    }
    void OnDisable()
    {
        _inWorldButton.OnIsActiveTrue -= SetMoveTrue;
    }
    bool isMove = false;
    void SetMoveTrue()
    {
        isMove = true;
    }

    private void Update()
    {
        if (isMove)
        {
            transform.position = transform.position + Vector3.up * Time.deltaTime;
        }
    }
}