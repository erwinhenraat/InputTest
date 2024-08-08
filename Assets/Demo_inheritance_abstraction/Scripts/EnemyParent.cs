using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    protected float moveSpeed;
    protected int lives;

    private Animator animator;
    // Start is called before the first frame update
    protected void Initialize()
    {
        Debug.Log("starting");
        animator = GetComponent<Animator>();
    }        
    protected void Move() {

        if(lives>0)transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) {
            lives--;
            if (lives <= 0) {
                animator.SetTrigger("Die");
            }
        }
    }

}
