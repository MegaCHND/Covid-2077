using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerButton : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 0;
    public Text text;

    void start(){
        text.enabled = true;
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer <8){
            timer+= Time.deltaTime;
            text.text = timer.ToString("0");
        }
        else{
            text.enabled = false;
        }
    }
}
