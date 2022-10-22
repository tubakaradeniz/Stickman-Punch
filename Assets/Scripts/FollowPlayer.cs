using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform Player;
    private Vector3 _offset;
    private void Start()
    {
        _offset = transform.position - Player.position;
    }

    void LateUpdate()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _offset.z);
        //transform.position = Player.transform.position + _offset ;
        transform.position = new Vector3(transform.position.x, transform.position.y, Player.position.z + _offset.z);

    }

}
