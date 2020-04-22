using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Vector3 force = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    public Vector3 velocity = Vector3.zero;
    public Vector3 arrivevelocity = new Vector3(10,10,10);
    public float mass = 1;
    public float damping = 0.01f;
    public float banking = 0.1f;
    public float slowing = 20f;
    public float maxSpeed = 5.0f;
    public float maxForce = 10.0f;
    public CarState carstate;
    public Vector3 target;
    public Vector3 desiredTarget;

    // Start is called before the first frame update
    void Start()
    {
        carstate = GetComponent<CarState>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public Vector3 SeekSteeringBehaviour(){
        transform.position += velocity * Time.deltaTime;
        velocity *= (1.0f - (damping * Time.deltaTime));
        desiredTarget = target - transform.position;
        desiredTarget.Normalize();
        desiredTarget *= maxSpeed;
        velocity = desiredTarget;
        if (desiredTarget - velocity == arrivevelocity){
            carstate.seek = true;
            carstate.decide = false;
            carstate.active = false;

        }
        return desiredTarget - velocity;
    }

    public Vector3 ArriveSteeringBehaviour(){
        transform.position += velocity / slowing * Time.deltaTime;
        if (desiredTarget - velocity == desiredTarget){
            carstate.arrive = true;
            carstate.seek = false;
            carstate.active = false;
        }
        return desiredTarget - velocity;
    }
}
