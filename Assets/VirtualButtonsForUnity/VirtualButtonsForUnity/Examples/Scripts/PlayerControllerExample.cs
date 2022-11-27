using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExample : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 2.0f;
   // [SerializeField] private float gravityValue = -9.81f;

    protected CharacterController controller;
    protected PlayerActionsExample playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    bool enableMobileInput;

    public float gravity ;

    private Vector3 moveDirection = Vector3.zero;

    public Animator anim;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = new PlayerActionsExample();
        anim.SetBool("Walking", false);

    }

    private void Update()
    {
        if (controller.isGrounded && moveDirection.y < 0)
        {
            moveDirection.y = 0f;
        }
        Vector2 movement = playerInput.Player.Move.ReadValue<Vector2>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(movement.x, 0.0f, movement.y);
            moveDirection *= playerSpeed;
        }
        if (moveDirection == new Vector3(0, 0, 0))
        {
            anim.SetBool("Walking", false);

        }
        else
        {
            anim.SetBool("Walking", true);
        }
        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
        if (moveDirection != new Vector3(0, 0, 0))
        {
            gameObject.transform.forward = moveDirection * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y,0) ;
        }


    }

        private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        moveDirection = Vector3.zero;
        playerInput.Disable();
    }

}
