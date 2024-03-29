using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI targetsHitText;
    public TextMeshProUGUI targetsMissedText;

    public int totalScore;
    public int targetsHit;
    public int targetsMissed;

    private void Start()
    {
        totalScore = 0;
        targetsHit = 0;
        targetsMissed = 0;
    }

    private void Update()
    {
        if(totalScore <= -1)
        {
            totalScore = 0;
            UpdateGUI();
        }
    }

    public void UpdateGUI()
    {
        scoreText.text = totalScore.ToString();
        targetsMissedText.text = targetsMissed.ToString();
        targetsHitText.text = targetsHit.ToString();
    }
}
