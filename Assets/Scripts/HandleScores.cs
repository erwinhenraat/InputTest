using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleScores : MonoBehaviour
{
    public HighScore highScoreObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highScoreObject.scores.Add(Random.Range(1, 10));
    }
}
