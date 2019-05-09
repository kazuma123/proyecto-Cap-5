﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonExecuteTest : MonoBehaviour
{
    private GameObject startButton, stopButton; private bool on = false; private float timer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("StartButton");
        stopButton = GameObject.Find("StopButton");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            on = !on;
            timer = 5.0f;

            PointerEventData data = new PointerEventData(EventSystem.current);
            if (on) {
                ExecuteEvents.Execute<IPointerClickHandler>(startButton, data, ExecuteEvents.pointerClickHandler);
            } else{
                ExecuteEvents.Execute<IPointerClickHandler>(stopButton, data, ExecuteEvents.pointerClickHandler);
            }
        }
    }
}
