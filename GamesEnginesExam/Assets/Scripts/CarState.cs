using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarState : MonoBehaviour
{
    public bool active;
    public bool decide;
    public bool seek;
    public bool arrive;
    public bool stopped;
    public trafficLights tl;
    public CarMovement carmove;
    public Vector3 chosentarget;
    public GameObject light;

    // Start is called before the first frame update
    void Start()
    {
        tl = GetComponent<trafficLights>();
        active = false;
        decide = false;
        seek = false;
        arrive = false;
        stopped = true;
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
            StartCoroutine(SeekLight());
        }

        if (seek == true){
            active = true;
            arrive = true;
            StartCoroutine(ArriveLight());
        }

        if (arrive == true){
            active = true;
            stopped = true;
        }
    }

    private IEnumerator Decide()
    {
        while (active == true){
            float amount = tl.amountoflights;
            int rand = Random.Range(1,11);
            light = GameObject.Find("Traffic Light " + (rand));
            var lightRend = light.GetComponent<Renderer>();
            var getcol = lightRend.material.GetColor("_Color");
            //Debug.Log("Colour = " + getcol + "Green = " + Color.green);
            if (getcol == Color.green){
                chosentarget = light.transform.position;
                carmove.target = chosentarget;
                stopped = false;
                decide = true;
                active = false;
            }
            yield return new WaitForFixedUpdate();
        }
        yield break;
    }

    private IEnumerator SeekLight()
    {
        while (active == true){
            var lightRend = light.GetComponent<Renderer>();
            var getcol = lightRend.material.GetColor("_Color");
            //Debug.Log("Colour = " + getcol + "Green = " + Color.green);
            if (getcol == Color.green){
                carmove.SeekSteeringBehaviour();
            }
            else{
                stopped = true;
                decide = false;
                active = false;
            }
            yield return new WaitForFixedUpdate();
        }
        yield break;
    }

    private IEnumerator ArriveLight()
    {
        while (active == true){
            var lightRend = light.GetComponent<Renderer>();
            var getcol = lightRend.material.GetColor("_Color");
            //Debug.Log("Colour = " + getcol + "Green = " + Color.green);
            if (getcol == Color.green){
                carmove.ArriveSteeringBehaviour();
            }
            else{
                stopped = true;
                decide = false;
                active = false;
            }
            yield return new WaitForFixedUpdate();
        }
        yield break;
    }
}
