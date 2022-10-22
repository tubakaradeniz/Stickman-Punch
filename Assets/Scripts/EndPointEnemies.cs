using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhysicState(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) *5*Time.deltaTime);
    }
    public Rigidbody[] rdoolbody;
    public void PhysicState(bool state)
    {
        foreach (Rigidbody childrenState in rdoolbody)
        {
            childrenState.isKinematic = state;
        }
    }
}
