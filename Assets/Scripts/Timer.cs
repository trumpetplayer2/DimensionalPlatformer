using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int timer = 0;
    public TextMeshProUGUI timerObject;
    private float nextUpdate = 0;
    // Start is called before the first frame update
    void Start()
    {
        nextUpdate = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextUpdate)
        {
            timer += 1;
            nextUpdate += 1;
        }
        timerObject.text = "Time: " + timer;
    }
}
