using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public Transform Player;
    //public BoxCollider CollectObject;
    public TextMeshProUGUI LevelText;
    public int Level;
    public Rigidbody _rigid;
    public EnemyCounter EnemyCountScript;
    public GameObject Sprite;
    public GameObject ForLerpSprite;

    public Tween jumpTween;

    void Start()
    {
        //rdoolbody = GetComponentsInChildren<Rigidbody>();
        //for ragdoll
        PhysicState(true);
        //ColliderState(false);


        //for enemy game object
        //_rigid = GetComponent<Rigidbody>();
        //CollectObject.enabled = true;
    }
    private void Update()
    {
        if (Player.transform.position.z > transform.position.z || transform.position.y>2)
        {
            LevelText.gameObject.SetActive(false);
        }
    }
    public Rigidbody[] rdoolbody;
    public void PhysicState(bool state)
    {
        foreach (Rigidbody childrenState in rdoolbody)
        {
            childrenState.isKinematic = state;
        }
    }
    public void ColliderState(bool state)
    {
        Collider[] cl = GetComponentsInChildren<Collider>();
        foreach (Collider childrenCollider in cl)
        {
            childrenCollider.enabled = state;
        }
    }
  
    public void LevelControl()
    {
        if (EnemyCountScript.LevelUpCrash <= Level)
        { 
            this.GetComponent<CapsuleCollider>().isTrigger = false;
        }
    }
    
    public IEnumerator LerpScale(float time)
    {
        Debug.Log("scale artýþ");
        var originalScale = ForLerpSprite.transform.localScale;
        var targetScale = originalScale + new Vector3(.4f, .4f, .4f);
        var originalTime = time;
        while (time > 0.0f)
        {
            time -= Time.deltaTime;
        }

        yield return ForLerpSprite.transform.localScale = Vector3.Lerp(targetScale, originalScale, time / originalTime);

    }
    public IEnumerator LerpDecrease(float time)
    {
        Debug.Log("scale düþüþ");
        var currentScale =ForLerpSprite.transform.localScale;
        var currentTargetScale = currentScale - new Vector3(.4f, .4f, .4f);
        var originalTime = time;
        while (time > 0.0f)
        {
            time -= Time.deltaTime;
        }

        yield return ForLerpSprite.transform.localScale = Vector3.Lerp(currentTargetScale, currentScale, time / originalTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("düþtün");
        }
    }
    //public IEnumerator LerpScale(float time)
    //{
    //    Debug.Log("yavrum nerdesin");
    //    var originalScale = ForLerpSprite.transform.localScale;
    //    var targetScale = originalScale + new Vector3(.4f, .4f, .4f);
    //    var originalTime = time;

    //while (time > 0.0f)
    //{
    //    time -= Time.deltaTime;
    //}
    //    yield return ForLerpSprite.transform.localScale = Vector3.Lerp(targetScale, originalScale, time / originalTime);

    //}

    public void Punch()  //burasý güncel
    {
        tag = "Collected";
        PhysicState(false);
        GetComponent<Animator>().enabled = false;
        _rigid.transform.DOLocalMoveY(0f, 0.4f); //burada olmazsa jumpBehaviour scriptinde yaz /0.5f
        GetComponent<CapsuleCollider>().isTrigger = false;
        new WaitForSeconds(0.1f); //0.15
       GetComponent<CapsuleCollider>().isTrigger = true;
    }
public IEnumerator PunchEffect()
    {
        //yield return new WaitForSeconds(0.1f);
        LevelControl();
        //Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        PhysicState(false);
        GetComponent<Animator>().enabled = false;
        transform.DOMoveZ(4.8f, 1.1f).SetRelative(true); //6 /5 /4.2f, 1f (4.8 de 5 kez vuruyor
        _rigid.transform.DOShakePosition(1);
        yield return transform.DOLocalMoveY(10, 0.75f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).WaitForCompletion(); //(5,0.5f)
        _rigid.transform.DOLocalMoveY(1.75f, 0.5f);

        GetComponent<CapsuleCollider>().isTrigger = false;

        yield return new WaitForSeconds(0.1f); //0.15
        // yield return new WaitForSeconds(0.1f);  deðeri günc
        GetComponent<CapsuleCollider>().isTrigger = true;
        //transform.DOMoveY(0.359f, 0.5f).SetEase(Ease.Linear);
        //_rigid.isKinematic = false;
        //_rigid.velocity += new Vector3(0, 15, 9.2f);
        //
        //ColliderState(true);
        //_rigid.isKinematic = true;
        //CollectObject.enabled = true;
        //PhysicState(true);
        //ColliderState(false);

    }
 
}
