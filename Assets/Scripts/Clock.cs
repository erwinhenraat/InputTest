using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Clock : MonoBehaviour
{
    public static Action OnTimeIsUp;

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
        if (started) {

            timeElapsed += Time.deltaTime;

            int totSeconds = totalTime - (int)Mathf.Round(timeElapsed);
            int secs = totSeconds % 60;
            int mins = totSeconds / 60;

            string secStr = IntToStringPrefixZero(secs);
            string minStr = IntToStringPrefixZero(mins);

            timefield.text = minStr + " : " + secStr;

            if (totSeconds <= 0) {
                OnTimeIsUp?.Invoke();
                started = false;
            }
        }
    }
    private void HandleStart() {
        started = true;
    }
    private void HandleFinish()
    {
        started = false;
    }
    private string IntToStringPrefixZero(int count)
    {
        string countStr;
        if(count >= 10)
        {
            countStr = count.ToString();
        }
        else
        {
            countStr = "0" + count.ToString();
        }
        return countStr;
    }
}
