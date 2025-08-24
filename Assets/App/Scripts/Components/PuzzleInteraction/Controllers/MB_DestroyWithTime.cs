namespace PuzzleInteraction.Controllers
{
    using System.Collections;
    using UnityEngine;

    public class MB_DestroyWithTime : MB_AbstractController
    {
        [SerializeField] float _timeSeconds = 5f;
        [SerializeField] protected GameObject _objectToDestroy;
        void Start()
        {
        }
        float _elapsed = 0f;
        bool _hasStarted = false;

        private void Update()
        {
            if (_hasStarted)
            {
                _elapsed += Time.deltaTime;
                if (_elapsed >= _timeSeconds)
                {
                    Destroy();
                }
            }
            
        }
        protected virtual void Destroy()
        {
            Destroy(_objectToDestroy);
        }
        public void StartCountdown()
        {
            _hasStarted = true;
        }
    }
}