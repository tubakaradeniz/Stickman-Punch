using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class JumpBehavior : MonoBehaviour
{
    public Transform ZPoint, YPoint;
    public float shapePower, shakeTime;
    public float minimum = 0;
    public float maximum = 100;
    public TextMeshProUGUI LevelText;
    public int LevelUpCrash = 1;
    // starting value for the Lerp
    static float t = 0.0f;
    private float blendShapeValue;
    private Animator PlayerAnim;
    private GameManager _gameManager;
    private void Start()
    {
        PlayerAnim = GetComponent<Animator>();
        _gameManager = GameManager.Instance;
    }
    void Update()
    {
        if (_gameManager.IsGameStart)
        {
            PlayerAnim.SetBool("Run", true);
        }
        if (_gameManager.IsGameStart == false)
        {
            PlayerAnim.SetBool("Run", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out Enemy enemy))
        {
            Camera.main.DOShakeRotation(shakeTime, shapePower, fadeOut: true);
            PlayerAnim.SetBool("Punch", true);
            enemy.Punch();
            LevelUpCrash++;
            Blend();
            enemy._rigid.transform.DOShakePosition(0.5f); //olmazsa tweenle yap
            float x = Random.Range(-1.3f, 1.3f);
           //s = Mathf.Clamp(s, -1.3f, 1.3f); //deneme
            Vector3 jumpPos = ZPoint.transform.position;
            //ZPoint.transform.localPosition = new Vector3(s, ZPoint.transform.localPosition.y, ZPoint.transform.localPosition.z);
            jumpPos.x = x;
            jumpPos.z += 1f;
            // other.transform.DOJump(ZPoint.position, 5, 1, 2f).SetEase(Ease.Linear);
            other.transform.DOJump(jumpPos, 8, 1, 4f).SetEase(Ease.OutExpo); //ZPoint.position, 10, 1, 3f
            ScoreUpdate();
            enemy.StartCoroutine("LerpScale", 0.5f);
            //new WaitForSeconds(1f);
            //enemy.StartCoroutine("LerpDecrease", 0.5f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            PlayerAnim.SetBool("Punch", false);
        }

    }
    public void ScoreUpdate()
    {
        LevelText.text = "Level " + LevelUpCrash.ToString();
    }
    private void Blend()
    {
        for (int i = 0; i < 100; i++)
        {
            blendShapeValue = Mathf.Lerp(minimum, maximum, t);
            t += 0.09f * Time.deltaTime;
        }
        GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(0, blendShapeValue);
    }

}
