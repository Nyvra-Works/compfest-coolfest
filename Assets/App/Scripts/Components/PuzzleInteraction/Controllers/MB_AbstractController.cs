using PuzzleInteraction.InteractionReceiver;
using UnityEngine;
namespace PuzzleInteraction.Controllers
{
    public abstract class MB_AbstractController : MonoBehaviour
    {
        public MB_AbstractInteractionReceiver _interactionReceiver;

        abstract protected void OnEnable();
        abstract protected void OnDisable();
    }
}