using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicScript : MonoBehaviour
{
 
    public float initialVelocity;
    public float accelaration;
    public TimerScript timerScript;

    public float currenVelocity;


    void Start()
    {
        currenVelocity = initialVelocity;
    }

    void FixedUpdate()
    {
        if(Time.fixedTime < timerScript.predictedTime)
        {
            currenVelocity += accelaration * Time.fixedDeltaTime;
            transform.Translate(Vector3.right * currenVelocity*Time.fixedDeltaTime);
        }

    }
}
