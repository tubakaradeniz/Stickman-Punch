using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double : MonoBehaviour
{
    private Animator DoubleAnim;

    void Start()
    {
        transform.DOMove(new Vector3(0, 0, 85), 2f);
        DoubleAnim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            DoubleAnim.SetBool("Punch", true);
        }
    }
    // Update is called once per frame
    void Update()
    {

        
    }
}
