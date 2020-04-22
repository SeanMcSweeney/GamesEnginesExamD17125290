﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficState : MonoBehaviour
{
    bool stoptimer;
    bool usingState;
    bool green;
    bool yellow;
    bool red;

    float amountoflights;
    trafficLights tl;
    void Start()
    {
        stoptimer = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChooseColour(float amountoflights)
    {
        for (float i = 0; i < amountoflights; i++){
        GameObject light = GameObject.Find("Traffic Light " + (i + 1));
        StartCoroutine(ChangeColour(light));
        }
        Debug.Log(amountoflights);
    }

    private IEnumerator ChangeColour(GameObject light)
    {
        usingState = false;
        while (true)
        {
            if (usingState == false){
                int colour = Random.Range(1,4);
                
                // 1 = green, 2 = yellow, 3 = red.

                if (colour == 1){
                    green = true;
                    yellow = false;
                    red = false;
                }
                else if (colour == 2){
                    green = false;
                    yellow = true;
                    red = false;
                }
                else if (colour == 3){
                    green = false;
                    yellow = false;
                    red = true;
                }
                else{
                    Debug.Log("error colour not chosen");
                    yield return null;
                }

                // set colours and times

                if (green == true){
                    int time = Random.Range(5,11);
                    float finaltime = time;
                    var lightRend = light.GetComponent<Renderer>();
                    lightRend.material.SetColor("_Color", Color.green);
                    usingState = true;
                    float timer = 0;
                    while(timer <= finaltime){
                        timer += Time.deltaTime;
                        yield return new WaitForFixedUpdate();
                    }
                    timer = 0;
                    usingState = false;
                }

                if (yellow == true){
                    int time = 4;
                    float finaltime = time;
                    usingState = true;
                    var lightRend = light.GetComponent<Renderer>();
                    lightRend.material.SetColor("_Color", Color.yellow);
                    float timer = 0;
                    while(timer <= finaltime){
                        timer += Time.deltaTime;
                        yield return new WaitForFixedUpdate();
                    }
                    timer = 0;
                    usingState = false;
                }

                if (red == true){
                    int time = Random.Range(5,11);
                    float finaltime = time;
                    usingState = true;
                    var lightRend = light.GetComponent<Renderer>();
                    lightRend.material.SetColor("_Color", Color.red);
                    float timer = 0;
                    while(timer <= finaltime){
                        timer += Time.deltaTime;
                        yield return new WaitForFixedUpdate();
                    }             
                    timer = 0;
                    usingState = false;
                }

            }
            else{
            }
            yield return new WaitForFixedUpdate();
        }
    }
}

