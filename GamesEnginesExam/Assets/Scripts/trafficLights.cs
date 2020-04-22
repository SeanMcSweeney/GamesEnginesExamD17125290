using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficLights : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateInCircle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateInCircle(){
        float circleSize = 8f;
        float amountoflights = 10f;
        float height = 2f;

        for (int i = 0; i < amountoflights; i++)
        {
            GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            float angle = i * Mathf.PI * 2f / amountoflights;
            Vector3 CirclePos = new Vector3(Mathf.Cos(angle) * circleSize, height, Mathf.Sin(angle) * circleSize);
            GameObject gameObj = Instantiate(capsule, CirclePos, Quaternion.identity);

            // Delete the created game objects without removing the circle of lights
            Destroy(capsule);
        }
    }
}
