using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBagObstacle : MonoBehaviour
{
    public Ease easy;
    public float shapePower;
    public float shakeTime;
    public GameObject Player;
    void Start()
    {
        transform.DORotate(new Vector3(0, 0, 90), 2, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo).SetEase(easy);
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Player"))
        {
            StartCoroutine(Crash());
           // other.transform.DOMove(other.transform.position - new Vector3(0, 0, 0.5f), 1).SetEase(Ease.OutBounce);
            Camera.main.DOShakePosition(shakeTime, shapePower, fadeOut: true);
            //Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - 5);
        }
    }

    IEnumerator Crash()
    {
        GameManager.Instance.PlayerSpeed = -3;
        yield return new WaitForSeconds(1f);
        GameManager.Instance.PlayerSpeed = 3;
    }
}
    


