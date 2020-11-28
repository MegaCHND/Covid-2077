using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerButton : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 0;


    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;
    }
    void OnGUI()
    {
        if (timer <=8){
            GUI.Label (new Rect(100, 100, 200, 100), timer.ToString("0"));
        }
        else{
            GUI.Label (new Rect(100, 100, 200, 100), "Done!!");
        }
    }
}
