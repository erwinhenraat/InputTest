using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    [SerializeField] private List <DustSettings> settings = new List<DustSettings>();
    [SerializeField] private GameObject dustPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //Listen to Action Event
        MoveCharacterController.OnJumpEvent += Spawn;
    }
    void Spawn(Vector3 location) {
        //Spawn effect
        GameObject effect = Instantiate(dustPrefab,transform);
        Dust dustScript = effect.GetComponent<Dust>();
        int r = Random.Range(0, settings.Count);
        Debug.Log(r);
        dustScript.Init(settings[r]);

        effect.transform.position = location;
        Destroy(effect,1.3f);
    }
}
