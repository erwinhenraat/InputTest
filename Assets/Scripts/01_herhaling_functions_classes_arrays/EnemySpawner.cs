using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject enemyPrefab;
    public List<GameObject> enemies = new List<GameObject>();
    public int waveSize = 10;
    private float elapsedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            //Spawn wave
            for (int i = 0; i < waveSize; i++) {

                enemies.Add(Instantiate(enemyPrefab, transform.position, Quaternion.identity));
            }

        }
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 3f) { 
            for (int i = 0;i < 3; i++) {
                enemies.Add(Instantiate(enemyPrefab, transform.position, Quaternion.identity));
            }
            elapsedTime = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            foreach (GameObject enemy in enemies) { 
                Destroy(enemy);
            }
            enemies.Clear();
            Debug.Log("enemies size"+enemies.Count);
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            StartCoroutine( RemoveOneByOne());
        }
    }

    IEnumerator RemoveOneByOne() {

        Destroy(enemies[0]);
        enemies.RemoveAt(0);

        yield return new WaitForSeconds(0.05f);

        if (enemies.Count != 0)StartCoroutine( RemoveOneByOne());
    }
}
