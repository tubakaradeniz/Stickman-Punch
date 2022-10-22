using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class EnemyCounter : MonoBehaviour
{
    public static EnemyCounter instance;
    public int EnemyCrashCount;
    public int LevelUpCrash =1;
    public TextMeshProUGUI LevelText;
    public bool IsCrashed = false;
    public ParticleSystem explosionParticle;
    public float shapePower, shakeTime;
    

    public List<GameObject> EnemyObj = new List<GameObject>();



    private void Awake()
    {
        instance = this;
    }
    public AnimationCurve curve;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            EnemyCrashCount++;
            LevelUpCrash++;
            IsCrashed = true;
            Camera.main.DOShakeRotation(shakeTime, shapePower, fadeOut: true);
           //enemy.Sprite.SetActive(false);
            //enemy.StartCoroutine("LerpScale",0.5f);
            StartCoroutine(other.GetComponent<Enemy>().PunchEffect());
            //Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
           
            StartCoroutine(WaitForEndAnimation());
            ScoreUpdate();

            //Sequence sequence = DOTween.Sequence();

            ////KillTweenIfActive(ref enemy.jumpTween);

            //Tween upTween = enemy.transform
            //    .DOJump(CalculateEndPosition(enemy.transform.position), 0, 1, 3.3f);

            //enemy.StartCoroutine("LerpScale", 0.5f);

            //Tween downTween = enemy.transform
            //    .DOJump(CalculateEndPosition(enemy.transform.position, false), 0, 1, 2.5f);

            //sequence.Insert(0, upTween).Insert(3.3f, downTween); //3.3f
            // enemy.Punch();


        }
    }
    Vector3 CalculateEndPosition(Vector3 startPosition,bool isUp=true)
    {
        float s = Random.Range(-1.2f, 1.2f);
        startPosition.x = s; // xe dnemee
        startPosition.y += isUp ? 10f : -10; //10,-10f
        startPosition.z += 11.1f; //5f / 11.1f;
        return startPosition;
    }
    IEnumerator WaitForEndAnimation()
    {
        yield return new WaitForSeconds(1f);
    }
    private void KillTweenIfActive(ref Tween tweener)
    {
        if (tweener != null && tweener.IsActive())
        {
            tweener.Kill();
            tweener = null;
        } 
    }
    public void ScoreUpdate()
    {
        LevelText.text ="Level "+ LevelUpCrash.ToString();
    }
  
}
