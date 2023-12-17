using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float score;

    private void Start()
    {
        ResetScore();
    }

    public void AddScore(float additional)
    {
        score += additional;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
