using System;
using UnityEngine;

namespace PuzzleInteraction.InteractionReceiver
{

    public class MB_AbstractInteractionReceiver : MonoBehaviour
    {
        public Action OnActiveChanged;
        public Action OnIsActiveTrue;
        public Action OnIsActiveFalse;
    }
}