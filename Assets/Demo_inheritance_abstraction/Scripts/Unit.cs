using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Unit : MonoBehaviour, IMovable, IDamagable
{
    // Start is called before the first frame update

    protected Animator animator;
    protected int lives;
    protected float moveSpeed = 2f;
    [SerializeField] GameObject player;   

    public void Initialize()
    {
        animator = GetComponent<Animator>();      
    } 
   
    public virtual void Move() {
        if (lives > 0 && animator.GetCurrentAnimatorStateInfo(0).IsName("Move")) transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage() {
        lives--;
        if (lives <= 0)
        {
            animator.SetTrigger("Die");
        }
    }

}
