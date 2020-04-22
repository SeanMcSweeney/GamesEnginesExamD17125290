using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCreate : MonoBehaviour
{
    public CarState carstate;

    // Start is called before the first frame update
    void Start()
    {
        CreateCar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCar(){
        GameObject car = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        car.transform.Rotate(90, 0, 0);
        car.transform.position = new Vector3(transform.position.x, transform.position.x + 1.2f, transform.position.z);
        var carRend = car.GetComponent<Renderer>();
        carRend.material.color = new Color32( 102, 0, 102, 200 );
        car.name = "Car";
        car.AddComponent<CarMovement>();
        carstate = GetComponent<CarState>();
        carstate.carmove = GameObject.Find("Car").GetComponent<CarMovement>();
    }
    
}
