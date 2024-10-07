using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brute : Unit, IMovable, IDamagable
{
    // Start is called before the first frame update
    void Start()
    {        
        Initialize();
        moveSpeed = 1;
        health = 15;
    }

    // Update is called once per frame
    void Update()
    {
        Move();        
    }
    
}
