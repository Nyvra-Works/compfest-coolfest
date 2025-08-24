namespace PuzzleInteraction.Controllers
{
    using UnityEngine;
    
    public class MB_DisableWithTime : MB_DestroyWithTime {
        protected override void Destroy()
        {
            _objectToDestroy.SetActive(false);
        }
    }
}