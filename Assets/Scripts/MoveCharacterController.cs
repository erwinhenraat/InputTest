using System;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))] 
public class MoveCharacterController : MonoBehaviour
{
    public static Action<Vector3> OnJumpEvent;
    private CharacterController characterController;
    private float jumpForce = 0f;
    [SerializeField] private float rotationSpeed = 90f;   
    [SerializeField] private float moveSpeed = 500f;    
    [SerializeField] private float hopForce = 20f;
    [SerializeField] private float normalJumpForce = 20f;
    [SerializeField] private float highJumpForce = 40f;
    [SerializeField] private float gravityFallScale = 3f;
    [SerializeField] private float gravityJumpScale = 1f;

  


    private Vector2 input = Vector2.zero;
    private Vector3 velocity;
    private float gravityScale = 1f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        velocity = Vector3.zero;
        jumpForce = normalJumpForce;
    }

    // Update is called once per frame
    void Update()
    {        
        float holdY = velocity.y;
        velocity = transform.forward * input.y * moveSpeed;
        velocity.y = holdY;
        if (velocity.y < 0){
            gravityScale = gravityFallScale;
        }
        else {
            gravityScale = gravityJumpScale;
        }
        if(velocity.y > Physics.gravity.y*gravityScale){
            velocity.y -= gravityScale;
        }
        characterController.Move(velocity*Time.deltaTime);        
        transform.Rotate(transform.up, input.x * rotationSpeed * Time.deltaTime);       
    }
    public void MoveInput(InputAction.CallbackContext context) {

        input.y = context.ReadValue<Vector2>().y;
        input.x = context.ReadValue<Vector2>().x;  
    }


    public void JumpInput(InputAction.CallbackContext context) {




        Debug.Log("phase : " + context.action.phase);
        Debug.Log("Interaction  : " + context.interaction.ToString());

        
        bool allowJump = false;
        if (context.action.phase == InputActionPhase.Performed)
        {

          

            switch (context.interaction.ToString())
            {
                case "UnityEngine.InputSystem.Interactions.TapInteraction":
                    jumpForce = hopForce;
                    Debug.Log("HOP");
                    allowJump = true;
                    break;
                case "UnityEngine.InputSystem.Interactions.HoldInteraction":                    
                    Debug.Log("Cancel Jump");
                    allowJump = false;
                    break;
            }

        }
        else if (context.action.phase == InputActionPhase.Canceled && context.interaction.ToString() == "UnityEngine.InputSystem.Interactions.HoldInteraction") {
            jumpForce = normalJumpForce;
            Debug.Log("NORMAL");
            allowJump = true;
        }
        if (allowJump) {
            Debug.Log("jumpforce is : " + jumpForce);
            if (characterController.isGrounded) velocity.y = jumpForce;
            OnJumpEvent?.Invoke(transform.position);
        }    
        
    } 

}
