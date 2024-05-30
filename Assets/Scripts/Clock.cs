using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private int totalTime = 90;
    private bool started = false;
    private float timeElapsed = 0;

    private TMP_Text timefield;
    // Start is called before the first frame update
    void Start()
    {
        TapToStart.OnStart += HandleStart;
        Racer.OnFinish += HandleFinish;
        timefield = GetComponent<TMP_Text>();
    }
   
    
    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(started);
        if (started) {
            
            timeElapsed += Time.deltaTime;

            int totSeconds = totalTime - (int)Mathf.Round(timeElapsed);
            int secs = totSeconds % 60;
            int mins = totSeconds / 60;

            timefield.text = mins + " : " + secs;            
        
        }
    }
    private void HandleStart() {
        started = true;
    }
    private void HandleFinish()
    {       
        started = false;
    }
}
