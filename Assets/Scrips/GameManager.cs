using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    CustomCircularDoubleLinkedList playerList = new CustomCircularDoubleLinkedList();
    PlayerMovement red;
    PlayerMovement purple;
    PlayerMovement blue;
    PlayerMovement orange;
    private void Awake()
    {
        playerList.Add(new CustomNode(red));
        playerList.Add(new CustomNode(purple));
        playerList.Add(new CustomNode(blue));
        playerList.Add(new CustomNode(orange));
    }
    public void MoveNext(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        playerList.MovePeakToNextTurn();
    }
    public void MovePrev(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        playerList.MovePeakToPrevTurn();
    }
}
