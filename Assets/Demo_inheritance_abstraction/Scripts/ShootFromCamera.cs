using UnityEngine;

public class ShootFromCamera : MonoBehaviour
{
    public GameObject projectilePrefab;
    private Plane floor;    
    void Start()
    {
        floor = new Plane(Vector3.up, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
        
            float dist;         
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (floor.Raycast(ray, out dist)) { 

                GameObject p = Instantiate(projectilePrefab, transform.position, transform.rotation);
                Vector3 wPos = ray.GetPoint(dist);
                p.transform.LookAt(wPos);
                p.AddComponent<MoveProj>();
                Destroy(p,3f);
            }       
        }
    }
}
public class MoveProj : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}

