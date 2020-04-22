using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehaviour : MonoBehaviour
{
    public float weight = 0.5f;
    public Vector3 force;

    [HideInInspector]
    public SeekTrafficLight seek;

    public void Awake()
    {
        seek = GetComponent<SeekTrafficLight>();
    }

    public abstract Vector3 Calculate();
}
