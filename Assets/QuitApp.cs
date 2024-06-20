using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuitApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string a = "hallov hahahahahahahahahaahah";
        Debug.Log("char count"+ a.Count<char>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
