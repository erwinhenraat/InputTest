using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Unit : MonoBehaviour, IMovable, IDamagable
{
    // Start is called before the first frame update

    protected Animator animator;
    protected int health;
    protected float moveSpeed = 2f;
    [SerializeField] private GameObject player;

    public enum Weapon { 
        Sword,
        Bow,
        Axe,
        MagicWand
    }

    public int Health { 
        get { return health; } 
    }

  
    public void Initialize()
    {
        animator = GetComponent<Animator>();      
    } 
   
    public virtual void Move() {
        if (health > 0 && animator.GetCurrentAnimatorStateInfo(0).IsName("Move")) transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage();

        }
    }
    
    public void TakeDamage() {
        health--;
        if (health <= 0)
        {
            animator.SetTrigger("Die");
        }
    }

}
