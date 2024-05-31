using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TapToStart : MonoBehaviour
{
    public static Action OnStart;
    private TMP_Text message;
    private bool onceStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        message = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !onceStarted) {
            OnStart?.Invoke();
            message.text = "";
            onceStarted = true;
        }
    }
}
