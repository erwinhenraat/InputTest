using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    [SerializeField] private GameObject effectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //Listen to Action Event
        MoveCharacterController.OnJumpEvent += Spawn;
    }
    void Spawn(Vector3 location) {
        //Spawn effect
        GameObject effect = Instantiate(effectPrefab,transform);
        effect.transform.position = location;
        Destroy(effect,1.3f);
    }
}
