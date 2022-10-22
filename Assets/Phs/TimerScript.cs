using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float predictedTime;
    public KinematicScript objectA;
    public KinematicScript objectB;
    public float fixedDeltaTimeValue;

    void Start()
    {
        Time.fixedDeltaTime = fixedDeltaTimeValue;
        CalculateTime();
    }

    private void CalculateTime()
    {
        // B 40 birim ileride
        float h = objectB.transform.position.x - objectA.transform.position.x;
        float a = objectB.accelaration - objectA.accelaration;
        float b = 2 * (objectB.initialVelocity - objectA.initialVelocity);
        float c = 2 * h;

        predictedTime = (-b - Mathf.Sqrt(b * b - 4 * a * c)) / (2*a); //+Math
        Debug.Log(predictedTime);
    }
   
}
