using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIscript : MonoBehaviour
{
    // Start is called before the first frame update

    public Text CoinsScore;
    public Text CoinDistance;

    public GameObject ArrowLeft;
    public GameObject ArrowRigth;

    private Vector3 LastVector;

    private string scoreTemplate; // template with text "Coins :"
    private uint coinScoreCount = 0;

    private string distanceTemplate;

    void Start()
    {
        ArrowLeft.SetActive(false);
        ArrowRigth.SetActive(false);
        scoreTemplate = CoinsScore.text;
        CoinsScore.text = scoreTemplate + coinScoreCount;

        distanceTemplate = CoinDistance.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCoinScore(uint score)
    {
        CoinsScore.text = scoreTemplate + score;
        coinScoreCount = score;
    }
    public void CoinScorePlusOne()
    {
        coinScoreCount++;
        CoinsScore.text = scoreTemplate + coinScoreCount;
    }

    public void SetCoinDistance(float distance)
    {
        CoinDistance.text = distanceTemplate + Mathf.Round( distance ) + " m";
    }

    public void RotateArrow(float rotation)
    {
        if (rotation > 0 && rotation <= 180)
        {
            if (ArrowRigth.activeSelf != true)
            {
                ArrowLeft.SetActive(false);
                ArrowRigth.SetActive(true);
            }
            
        }
        if (rotation < 0 && rotation >= -180)
        {
            if (ArrowLeft.activeSelf != true)
            {
                ArrowLeft.SetActive(true);
                ArrowRigth.SetActive(false);
            }
        }

    }
}
