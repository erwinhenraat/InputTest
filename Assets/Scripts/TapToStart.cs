using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToStart : MonoBehaviour
{
    public static Action OnStart;
    public static Action OnReset;
    [SerializeField] private float waitTime = 1f; 

    private TMP_Text message;
    private bool onceStarted = false;
    private bool restartActive = false;

   
    // Start is called before the first frame update
    void Start()
    {

        message = GetComponent<TMP_Text>();


        Clock.OnTimeIsUp += RestartMessage;
        Racer.OnFinish += RestartMessage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !onceStarted) {
            OnStart?.Invoke();
            message.text = "";
            onceStarted = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && restartActive) {
            StartCoroutine(waitAndReset());
            

        }
    }
    IEnumerator waitAndReset() {
        // resetten ipv laden scene
        yield return new WaitForSeconds(waitTime);
        onceStarted = false;
        restartActive = false;
        message.text = "Tap space! \n to start race!";
        OnReset?.Invoke();
    }
    void RestartMessage()
    {
        //wait
        message.text = "Press Space to Restart!";
        restartActive = true;

    }


}
