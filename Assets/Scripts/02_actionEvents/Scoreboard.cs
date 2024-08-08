using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Scoreboard : MonoBehaviour
{
    private int score = 0;
    private TMP_Text textfield; 
    // Start is called before the first frame update
    void Start()
    {
        Pickup.OnPickup += AddScore;
        textfield = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AddScore(int value) {
        Debug.Log("adding score");
        score += value;
        textfield.text = "Score : " + score;
    }
}
