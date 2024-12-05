using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLife : MonoBehaviour
{
    private Animator animator;
    private int lives = 5;
    public static event Action onHeroDeath;
    // Start is called before the first frame update

    public int Lives {
        get { 
            return lives;
        }    
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Delete)) {
        
            lives--;
            animator.SetInteger("lives", lives);

            if (lives == 0) {
                onHeroDeath?.Invoke();
            }
        }
    }
}
