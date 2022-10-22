using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchManagement : MonoBehaviour
{
    public Transform ZPoint, YPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            float s = Random.Range(-1.3f, 1.3f);
            other.transform.DOLocalMoveY(12, 0.75f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).WaitForCompletion();
            other.transform.DOMoveZ(15f, 1f).SetRelative(true);
            other.transform.position = new Vector3(s, other.transform.position.y, transform.position.z + 1);

            //other.transform.DOLocalMoveY(15, 0.75f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).WaitForCompletion();
            //other.transform.DOMoveZ(15f, 1f).SetRelative(true);
            // other.transform.position = new Vector3 (other.transform.position.x, other.transform.position.y,transform.position.z+1);

        }
    }
}
