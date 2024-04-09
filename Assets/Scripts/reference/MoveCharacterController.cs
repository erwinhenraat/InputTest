using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


[RequireComponent(typeof(CharacterController))] 
public class MoveCharacterController : MonoBehaviour
{
    public static Action<Vector3> OnJumpEvent;
   
    [SerializeField] private float rotationSpeed = 90f;   
    [SerializeField] private float moveSpeed = 500f;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float gravityFallScale = 3f;
    [SerializeField] private float gravityJumpScale = 1f;    

    private CharacterController characterController;    
    private Vector2 input = Vector2.zero;
    private Vector3 velocity;
    private float gravityScale = 1f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        velocity = Vector3.zero;
        /*
         * tried to add input an binding thrue pure code. Does not yet work
        InputAction jumpAction = new InputAction();
        jumpAction.AddBinding("<Keyboard>/Space").WithInteractions("tap;press;hold");
       
        jumpAction.performed +=
            context =>
            {

                Debug.Log("asfdg");
                if (context.interaction is TapInteraction)
                {
                    jumpForce = hopForce;
                }
                else if(context.interaction is PressInteraction)
                {
                    jumpForce = normalJumpForce;
                }
                else if (context.interaction is HoldInteraction)
                {
                    jumpForce += highJumpForce;
                }

                Jump();
            };

        */
    }    
    void Update()
    {        
        //update only the X an Z axes
        float holdY = velocity.y;
        velocity = transform.forward * input.y * moveSpeed;
        velocity.y = holdY;

        //use gravity scales to improve the gamefeel of the jump slowup/fastdown
        if (velocity.y < 0){
            gravityScale = gravityFallScale;
        }
        else {
            gravityScale = gravityJumpScale;
        }
        //adjust velocity of the player with the gravity
        if(velocity.y > Physics.gravity.y*gravityScale){
            velocity.y -= gravityScale;
        }
        //move player controller with velocity
        characterController.Move(velocity*Time.deltaTime);        
        //rotate player
        transform.Rotate(transform.up, input.x * rotationSpeed * Time.deltaTime);       
    }
    private void Jump()
    {
        //Jump the character controller
        if (characterController.isGrounded) velocity.y = jumpForce;
        //Send Action Event
        OnJumpEvent?.Invoke(transform.position);
    }
    public void MoveInput(InputAction.CallbackContext context) {
        //get input from Input Action Asset 
        input.y = context.ReadValue<Vector2>().y;
        input.x = context.ReadValue<Vector2>().x;  
    }  
    public void JumpInput(InputAction.CallbackContext context) {
        //get input from Input Action Asset
        if (context.action.phase == InputActionPhase.Performed)
        {
            Jump();
        }            
    } 
}
