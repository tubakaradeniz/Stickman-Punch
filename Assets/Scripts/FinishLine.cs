using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public TextMeshProUGUI LevelText;
    public GameObject FinishCam,DoublePlayer,Player;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.PlayerSpeed = 0;
            GameManager.Instance.IsGameStart = false;
            LevelText.gameObject.SetActive(false);
            FinishCam.SetActive(true);
            DoublePlayer.SetActive(true);
            Player.SetActive(false);



        }
    }
}
