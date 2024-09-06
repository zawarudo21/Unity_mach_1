using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Script : MonoBehaviour
{
    public float time_remaining = 30.00f;
    public Text timer_text;
    public Text game_over_text;
    public bool timer_running = true;


    // Start is called before the first frame update
    void Start()
    {
        timer_running = true;
        game_over_text.gameObject.SetActive(false);
        Update_Timer_Display();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer_running)
            time_remaining -= Time.deltaTime;

        if(time_remaining > 0)
        {
            Update_Timer_Display();
        }

        else
        {
            timer_running = false;
            time_remaining = 0.00f;
            Update_Timer_Display();
            End_Game();
        }
    }

    void Update_Timer_Display()
    {
        timer_text.text = time_remaining.ToString("F2");
    }

    void End_Game()
    {
        game_over_text.gameObject.SetActive(true);
        StartCoroutine(ChangeTextColor());
        Time.timeScale = 0f;
    }

    IEnumerator ChangeTextColor()
    {
        while (true)
        {
            // Lerp color between red and blue over 1 second
            float t = Mathf.PingPong(Time.unscaledTime, 1f);
            game_over_text.color = Color.Lerp(Color.red, Color.blue, t);

            // Yield until the next frame
            yield return null;
        }
    }
}
