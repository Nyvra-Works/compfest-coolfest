namespace PuzzleInteraction.Controllers
{
    using UnityEngine;

    public class MB_GoTo : MB_AbstractController
    {
        [SerializeField] private Transform _objectToChange;
        [SerializeField] private Vector3 _move;
        
        private Vector3 _oldPosition;
        void Start()
        {
            _oldPosition = _objectToChange.position;
        }

        public void Transition()
        {
            _objectToChange.position += _move;
        }
    }
}