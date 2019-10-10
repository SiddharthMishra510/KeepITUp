using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;
    Vector3 mousePos;

    private void FixedUpdate()
    {
        controller.Move(Input.mousePosition);
    }
}