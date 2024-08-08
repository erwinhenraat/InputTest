
using UnityEngine;



public class TowerSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform floorPositionReference;
    private Plane floor;
    // Start is called before the first frame update
    void Start()
    {
        floor = new Plane(Vector3.up, floorPositionReference.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {

            /*
            float dist;         
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (floor.Raycast(ray, out dist)) { 
                Vector3 wPos = ray.GetPoint(dist);
                Instantiate(prefab, wPos, Quaternion.identity);
            }*/

            float x = Random.Range(-5f, 5f);
            float y = 0f;
            float z = Random.Range(-5f, 5f);

            Vector3 rPos = new Vector3(x,y,z);
                 
            Instantiate(prefab, rPos, Quaternion.identity);

        }
          
       
    }
}
