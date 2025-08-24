using PuzzleInteraction.Controllers;
using UnityEngine;

namespace PuzzleInteraction.Controllers
{
    public class MB_MoveLalalalala : MB_AbstractController
    {

        bool isMove = false;
        public void SetMoveTrue()
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