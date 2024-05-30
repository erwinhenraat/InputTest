using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TapToStart : MonoBehaviour
{
    public static Action OnStart;
    private TMP_Text message;
    // Start is called before the first frame update
    void Start()
    {
        message = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            OnStart?.Invoke();
            message.text = "";
        }
    }
}
