using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    private Transform cameraTransform;

    private InputManager inputManager;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 movement = inputManager.GetPlayerMovement();

        Vector3 move = new Vector3(movement.x, 0f, movement.y);

        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;

        controller.Move(move * Time.deltaTime * playerSpeed);

        controller.Move(playerVelocity * Time.deltaTime);
    }
}