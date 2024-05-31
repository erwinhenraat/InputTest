using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Racer : MonoBehaviour
{
    public static Action OnFinish;

    private float currentSpeed = 0;

    private Animator animator;
    private bool finished = false;
    private bool lost = false;

    [SerializeField] private float speedIncrease = 0.2f;

    [SerializeField] private float speedDecrease = 0.02f;

    [SerializeField] private float maxSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Clock.OnTimeIsUp += Lose;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished && !lost)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("tap!");
                Tap();
            }
            Animate();
            Move();
        }
    }
  
    private void Tap() {
        currentSpeed += speedIncrease;


    }
    private void Move()
    {
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        if(currentSpeed > 0)currentSpeed -= speedDecrease;

    }
    private void Animate() {
        if (currentSpeed > 0) {

            if(currentSpeed > maxSpeed)currentSpeed = maxSpeed;

            float aniSpeed = 1 + currentSpeed / 10;
            animator.speed = aniSpeed;

            if (!animator.GetCurrentAnimatorStateInfo(0).Equals("Run")) {
                animator.SetTrigger("Run");
                animator.ResetTrigger("Idle");
            }
        }
        else
        {
            
            if (!animator.GetCurrentAnimatorStateInfo(0).Equals("Idle")) {
                animator.speed = 1;
                animator.SetTrigger("Idle");
                animator.ResetTrigger("Run");
            }

        }
    }
    void OnTriggerExit(Collider other)
    {
        
        if (other.tag == "Finish") {
            animator.speed = 1;
            finished = true;
            animator.SetTrigger("Win");
            animator.ResetTrigger("Run");
            OnFinish?.Invoke();
        }
    }
    private void Lose() {
        lost = true;
        animator.speed = 1;
        animator.SetTrigger("Lose");
        animator.ResetTrigger("Run");
    }
}
