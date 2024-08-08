using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Balls : MonoBehaviour
{
    public GameObject prefab;
    private float elapsedTime = 0f;
    // Start is called before the first frame update
    Balls() { 
    
    }
    void Start()
    {
        for (int i = 0; i < 100; i++){           
            Color color = RandomColor();
            Vector3 randPos = RandomPosition(-10f, 10f);
            CreateBall(color, randPos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 1f) {
            Color color = RandomColor();
            Vector3 randPos = RandomPosition(-10f, 10f);
            GameObject ball = CreateBall(color, randPos);
            DestroyBall(ball);
            elapsedTime = 0f;
        }
    }

    private GameObject CreateBall(Color c, Vector3 position) {
        GameObject ball = Instantiate(prefab, position, Quaternion.identity);
        Material material = ball.GetComponent<MeshRenderer>().material;
        material.SetColor("_Color",c);
        return ball;

    }
    private void DestroyBall(GameObject ball) {
        Destroy(ball, 3f);
    }

    private Vector3 RandomPosition(float min, float max)
    {
        float x = Random.Range(min, max);
        float y = Random.Range(min, max);
        float z = Random.Range(0f, max);
        Vector3 position = new Vector3(x,y,z);
        return position;
    }

    private Color RandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        Color color = new Color(r,g,b,1f);
        return color;
    }
}
