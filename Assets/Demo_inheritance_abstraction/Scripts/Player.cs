using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit, IMovable, IDamagable
{
    [SerializeField] float rotationSpeed = 120f;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        lives = 15;
        moveSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();    
    }
    public override void Move()
    {
        if (lives > 0)
        {
            if (Input.GetAxis("Vertical") == 0) {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    animator.SetTrigger("Idle");
                    animator.ResetTrigger("Move");
                }
            }
            else {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Move")) {
                    animator.SetTrigger("Move");
                    animator.ResetTrigger("Idle");
                }
            } 
            
               
            transform.position += transform.forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            transform.Rotate(Vector3.up*rotationSpeed*Time.deltaTime * Input.GetAxis("Horizontal"));
            
        }
    }
   
}
