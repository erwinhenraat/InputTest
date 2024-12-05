using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTransform : MonoBehaviour
{
    [SerializeField]private float speed = 80f;
    [SerializeField] private float rotationAngle = 80f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(transform.up, rotationAngle * Time.deltaTime * Input.GetAxis("Horizontal"));

        Vector3 move = transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        transform.position += move;

        


    }
}
