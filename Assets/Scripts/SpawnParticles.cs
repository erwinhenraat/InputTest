using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    [SerializeField] private GameObject effectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        MoveCharacterController.OnJumpEvent += Spawn;
    }
    void Spawn(Vector3 location) {
        GameObject effect = Instantiate(effectPrefab);
        effect.transform.position = location;
    }
}
