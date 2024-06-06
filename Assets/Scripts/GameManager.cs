using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PlayerScoreL = 0;
    public int PlayerScoreR = 0;

    public Slider playerslider;
    public Slider botslider;

    public GameObject P1Win;
    public GameObject P2Win;
    public GameObject Backbutton;

    public GameObject LGoal;
    public GameObject RGoal;

    public Text txtPlayerScoreL;
    public Text txtPlayerScoreR;
    
    public static GameManager instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        txtPlayerScoreL.text = PlayerScoreL.ToString();
        txtPlayerScoreR.text = PlayerScoreR.ToString();
        playerslider.value = 0; botslider.value = 0;
    }

    public void Score(string wallID)
    {
        if (wallID == "LGoal")
        {
            PlayerScoreL = PlayerScoreL + 1;
            txtPlayerScoreL.text = PlayerScoreL.ToString();
            playerslider.value = PlayerScoreL;
        }
        else if (wallID == "RGoal")
        {
            PlayerScoreR = PlayerScoreR + 1;
            txtPlayerScoreR.text = PlayerScoreR.ToString();
            botslider.value = PlayerScoreR;
        }
        ScoreCheck();
    }
    public void ScoreCheck()
    {
        if (PlayerScoreL == 5)
        {
            //Debug.Log("playerR win");
            P2Win.SetActive(true);
            Backbutton.SetActive(true);

            BoxCollider2D kiri = LGoal.GetComponent<BoxCollider2D>();
            kiri.isTrigger = false;

            BoxCollider2D kanan = RGoal.GetComponent<BoxCollider2D>();
            kanan.isTrigger = false;

        }
        else if (PlayerScoreR == 5)
        {
            //Debug.Log("playerL win");
            P1Win.SetActive(true);
            Backbutton.SetActive(true);

            BoxCollider2D kiri = LGoal.GetComponent<BoxCollider2D>();
            kiri.isTrigger = false;

            BoxCollider2D kanan = RGoal.GetComponent<BoxCollider2D>();
            kanan.isTrigger = false;

        }
    }
}