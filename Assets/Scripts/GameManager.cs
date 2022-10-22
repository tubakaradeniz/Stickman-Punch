using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
   // public List<GameObject> Enemies = new List<GameObject>();
    public List<GameObject> Enemies;
    public GameObject finishPanel;
    public TextMeshProUGUI TapToPlayText;
    [HideInInspector] public bool IsGameStart = false;
    [HideInInspector] public bool IsGameFinish = false;
    public float PlayerSpeed =3;

    private void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        if (IsGameFinish)
        {
            Invoke(nameof(FinishPanelActive), 2);
        }
        if (Input.GetMouseButton(0)) //GetMouseButtonUp(0))
        {
            IsGameStart = true;
            TapToPlayText.gameObject.SetActive(false);

        }
    }
    public void FinishPanelActive()
    {
        finishPanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
