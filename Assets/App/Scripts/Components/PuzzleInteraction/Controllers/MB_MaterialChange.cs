namespace PuzzleInteraction.Controllers
{
    using UnityEngine;

    public class MB_MaterialChange : MB_AbstractController
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Material _transitionToColor;
        
        private Material _realMaterial;
        void Start()
        {
            _realMaterial = _renderer.material;

        }

        public void Transition()
        {
            _renderer.material = _transitionToColor;
        }

    }
}