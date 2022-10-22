using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlyer : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;

    private float _borderPos = 1.8f;
    private float _distanceX;
    private Vector3 _firstPos, _endPos;

   

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
    private void Update()
    {
        Swerve();
    }
    public void Swerve()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _firstPos = Input.mousePosition;

        }

        if (Input.GetMouseButton(0))
        {
            _endPos = Input.mousePosition;

            Vector2 touchDelta = (_endPos - _firstPos);

            _distanceX = (transform.position.x + (touchDelta.x * 0.015f)); //0.01f
            _distanceX = Mathf.Clamp(_distanceX, -_borderPos, _borderPos);

            transform.position = new Vector3(_distanceX, transform.position.y, transform.position.z);
            //transform.position = Vector3.Lerp(transform.position, new Vector3(_distanceX + .3f,
            //  transform.position.y, transform.position.z), _turnSpeed);
            _firstPos = Input.mousePosition;
        }
    }
}
