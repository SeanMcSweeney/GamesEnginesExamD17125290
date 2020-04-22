using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Vector3 force = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    public Vector3 velocity = Vector3.zero;
    public float mass = 1;
    public float damping = 0.01f;
    public float banking = 0.1f;
    public float maxSpeed = 5.0f;
    public float maxForce = 10.0f;
    public CarState carstate;
    public Vector3 target;

    public bool wft;
    public bool carwait;


    // Start is called before the first frame update
    void Start()
    {
        wft = false;
        carstate = GetComponent<CarState>();
        carwait = false;
    }

    // Update is called once per frame
    void Update()
    {
        carwait = carstate.waitfortarget;
        if (carwait == true){
        wft = carwait;
        }
        if (wft == true){
        target = carstate.chosentarget;
        force = new Vector3(10,10,10);
        Vector3 newAcceleration = force / mass;
        acceleration = Vector3.Lerp(acceleration, newAcceleration, Time.deltaTime);
        velocity += acceleration * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * banking), Time.deltaTime * 3.0f);
        transform.LookAt(transform.position + velocity, tempUp);

        transform.position += velocity * Time.deltaTime;
        velocity *= (1.0f - (damping * Time.deltaTime));
        }
        else
        {
            //Debug.Log("off");
        }
    }

    public Vector3 SeekSteeringBehaviour(){
        Vector3 desiredTarget = target - transform.position;
        desiredTarget.Normalize();
        desiredTarget *= maxSpeed;
        return desiredTarget - velocity;
    }

    public void ArriveSteeringBehaviour(){
    }
}
