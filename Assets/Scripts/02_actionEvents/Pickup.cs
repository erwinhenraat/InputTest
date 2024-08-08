using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int value = 50;
    public static event Action<int> OnPickup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player")) {
            OnPickup?.Invoke(value);
            Destroy(gameObject);
            Debug.Log("triggered");

        }
    }
}
