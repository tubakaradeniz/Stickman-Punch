using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shake : MonoBehaviour
{
    public float shapePower;
    public float shakeTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.DOShakePosition(shakeTime, shapePower,fadeOut:true); //fade out ,shake biterken daha yumuþak bir bitiþ olmasý için
        Camera.main.DOShakeRotation(shakeTime, shapePower, fadeOut: true);
    }
}
