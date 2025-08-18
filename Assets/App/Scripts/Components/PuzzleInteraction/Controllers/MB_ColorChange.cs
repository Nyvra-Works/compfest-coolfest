namespace PuzzleInteraction.Controllers
{
    using UnityEngine;

    public class MB_ColorChange : MB_AbstractController
    {
        [SerializeField] Renderer _renderer;
        [SerializeField] Color _transitionToColor;
        private Color _realColor;
        void Start()
        {
            _realColor = _renderer.material.color;
        }

        protected override void OnDisable()
        {
            this._interactionReceiver.OnIsActiveTrue -= TransitionToColor;
        }

        protected override void OnEnable()
        {
            this._interactionReceiver.OnIsActiveTrue += TransitionToColor;
        }
        void TransitionToColor()
        {
            _renderer.material.color = _transitionToColor;
        }

    }
}