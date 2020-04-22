using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCreate : MonoBehaviour
{
    CarState carstate;
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
        carstate = GetComponent<CarState>();
        //carstate.ChooseColour(amountoflights);
    }
    
}
