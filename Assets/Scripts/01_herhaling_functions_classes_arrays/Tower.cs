using UnityEngine;

public class Tower:MonoBehaviour
{
    private void Start()
    {
        
        float scale = Random.Range(0.01f, 1f);
        transform.localScale = Vector3.one*scale;
        
      

        

    }



}
