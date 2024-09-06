using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_manager_script : MonoBehaviour
{
    public int score = 0;
    public Text score_text;

    [ContextMenu("increase score")]
    public void AddScore()
    {
        score += 1;
        score_text.text = score.ToString();
       
    }

    private void Start()
    {
        score_text.text = score.ToString();
    }
}
