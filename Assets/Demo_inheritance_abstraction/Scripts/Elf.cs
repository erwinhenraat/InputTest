using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : Unit, IMovable, IDamagable
{
    private float elapsedTime = 0f;
    private Renderer r;
    // Start is called before the first frame update
    void Start()
    {        
        Initialize();
        moveSpeed = 2f;
        lives = 5;
        r = GetComponentInChildren<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
     
        ToggleVisibility();
        Move();
       
    }

    private void ToggleVisibility() {
      
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 2f && r.enabled && lives > 0)
        {
            r.enabled = false;
            elapsedTime = 0f;
        }
        else if (!r.enabled && elapsedTime > 0.5f)
        {
            r.enabled = true;
            elapsedTime = 0f;
        }
        
    }
  
}
