using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreValue;

    [SerializeField] TMP_Text jumpsValue;
    // Start is called before the first frame update


    public void UpdateScore(int currentScore)
    {
        scoreValue.text = currentScore.ToString();
    }

    public void UpdateJumps(int currentJumps)
    {
        jumpsValue.text = currentJumps.ToString();
    }
}
