using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficLights : MonoBehaviour
{
    public float amountoflights;
    TrafficState ts;
    // Start is called before the first frame update
    void Start()
    {
        CreateInCircle();
    }

    public void CreateInCircle(){
        float circleSize = 8f;
        amountoflights = 10f;
        float height = 2f;

        for (int i = 0; i < amountoflights; i++)
        {
            GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            GameObject capsuleSetPos = Instantiate(capsule, new Vector3(0, 0, 0), Quaternion.identity);
            float angle = i * Mathf.PI * 2f / amountoflights;
            Vector3 CirclePos = new Vector3(Mathf.Cos(angle) * circleSize, height, Mathf.Sin(angle) * circleSize);
            GameObject gameObj = Instantiate(capsuleSetPos, CirclePos, Quaternion.identity);
            gameObj.name = "Traffic Light " + (i + 1);

            // Delete the created game objects without removing the circle of lights
            Destroy(capsule);
            Destroy(capsuleSetPos);
        }

        ts = GetComponent<TrafficState>();
        ts.ChooseColour(amountoflights);
    }
}
