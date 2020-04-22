using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarState : MonoBehaviour
{
    bool active;
    bool decide;
    bool seek;
    bool arrive;
    bool stopped;
    public trafficLights tl;
    public Vector3 chosentarget;
    public CarMovement carmove;
    public bool waitfortarget;

    // Start is called before the first frame update
    void Start()
    {
        tl = GetComponent<trafficLights>();
        carmove = GetComponent<CarMovement>();
        active = false;
        decide = false;
        seek = false;
        arrive = false;
        stopped = true;
        waitfortarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == false){
        ChooseState();
        }
    }

    public void ChooseState(){

        if (stopped == true){
            active = true;
            decide = true;
            StartCoroutine(Decide());
        }

        if (decide == true){
            active = true;
            seek = true;
            //carmove.SeekSteeringBehaviour();
        }

        if (seek == true){
            active = true;
            arrive = true;
            //carmove.ArriveSteeringBehaviour();
        }

        if (arrive == true){
            active = true;
            stopped = true;
        }
    }

    private IEnumerator Decide()
    {
        while (true){
            float amount = tl.amountoflights;
            int rand = Random.Range(1,11);
            GameObject light = GameObject.Find("Traffic Light " + (rand));
            var lightRend = light.GetComponent<Renderer>();
            var getcol = lightRend.material.GetColor("_Color");
            //Debug.Log("Colour = " + getcol + "Green = " + Color.green);
            if (getcol == Color.green){
                chosentarget = light.transform.position;
                waitfortarget = true;
                active = false;
                yield return null;
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
