using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl : MonoBehaviour
{
    private Animator PlayerAnim;
    private GameManager _gameManager;
    //public SkinnedMeshRenderer skinnedMeshRenderer;

    public float minimum = 0;
    public float maximum = 100;
    // starting value for the Lerp
    static float t = 0.0f;
    private float blendShapeValue;

    void Start()
    {
        _gameManager = GameManager.Instance;
        PlayerAnim = GetComponent<Animator>();
        
    }
    private void Awake()
    {
        //skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
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
        if (other.CompareTag("Enemy") || other.CompareTag("Collected"))
        {
            PunchAnim();
            for (int i = 0; i < 100; i++)
            {
                blendShapeValue = Mathf.Lerp(minimum, maximum, t);
                t += 0.09f * Time.deltaTime;
            }
            GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(0, blendShapeValue);
        }
    }
    public void PunchAnim()
    {
        PlayerAnim.SetBool("Punch", true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            PlayerAnim.SetBool("Punch", false);
        }

    }
    //public void SetFalse()
    //{
    //  PlayerAnim.SetBool("Punch", false);
    //}

}
