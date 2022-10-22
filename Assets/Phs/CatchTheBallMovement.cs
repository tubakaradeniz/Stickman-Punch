using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTheBallMovement : MonoBehaviour
{
    public static CatchTheBallMovement Instance;

    public float speed;
    public Transform target;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //if (Input.GetMouseButtonUp(0))
        //{
            
        //    MakeTargetRandom();
        //}
    }

    public void CalculateMovement(float time)
    {
        float dist = target.position.x - transform.position.x;
        speed = dist / time;  
    }
    private void MakeTargetRandom()
    {
        int random = Random.Range(-1, 1);
        Vector3 newPos = target.position;
        newPos.x = random;
        target.position = newPos;
    }
}
