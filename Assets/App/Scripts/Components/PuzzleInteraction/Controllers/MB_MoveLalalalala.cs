using PuzzleInteraction.Controllers;
using UnityEngine;

namespace PuzzleInteraction.Controllers
{
    public class MB_MoveLalalalala : MB_AbstractController
    {

        protected override void OnEnable()
        {
            _interactionReceiver.OnIsActiveTrue += SetMoveTrue;
        }
        protected override void OnDisable()
        {
            _interactionReceiver.OnIsActiveTrue -= SetMoveTrue;
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
}