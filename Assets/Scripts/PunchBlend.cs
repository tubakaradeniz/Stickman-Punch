using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchBlend : MonoBehaviour
{
    public Ease easy;
    public float shapePower;
    public float shakeTime;
    public GameObject Player;
    void Start()
    {
        transform.DOMoveX(-2, 1.5f).SetLoops(15, LoopType.Yoyo).SetEase(easy).OnComplete(() =>
        {
            transform.DOMoveX(-2f, 1.5f);
        });
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Crash());
            // other.transform.DOMove(other.transform.position - new Vector3(0, 0, 0.5f), 1).SetEase(Ease.OutBounce);
            Camera.main.DOShakePosition(shakeTime, shapePower, fadeOut: true);
            
        }
    }

    IEnumerator Crash()
    {
        GameManager.Instance.PlayerSpeed = -3;
        yield return new WaitForSeconds(1f);
        GameManager.Instance.PlayerSpeed = 3;
    }
}
