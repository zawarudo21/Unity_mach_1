using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Moving_Ball : MonoBehaviour
{

    public float movespeed = 50;
    private float time_in_view = 0f;
    private float threshold = 2f;
    public bool ready_to_delete = false;
    public bool deleted = false;
    private Renderer BallRenderer;
    public score_manager_script score_manager;
    public Timer_Script time_script;
    //public AudioManagerScript audio_manager;
    public AudioClip balloon_pop;
    private AudioSource audiosource;
    public bool play_sound = false;

    // Start is called before the first frame update
    void Start()
    {
        BallRenderer = GetComponent<Renderer>();
        score_manager = GameObject.FindGameObjectWithTag("score_manager").GetComponent<score_manager_script>();
        time_script = GameObject.FindGameObjectWithTag("Time_Manager").GetComponent<Timer_Script>();
        //audio_manager = GameObject.FindGameObjectWithTag("Audio_manager").GetComponent<AudioManagerScript>();
        audiosource = gameObject.AddComponent<AudioSource>();
        audiosource.clip = balloon_pop;
        audiosource.playOnAwake = false;

        if(balloon_pop == null)
        {
            Debug.Log("balloon pop is null");
        }

        if(audiosource == null)
        {
            Debug.Log("audiosource is null");
        }

        if (audiosource.clip == null)
        {
            Debug.Log("in start, audiosource clip null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("movespeed is " + movespeed);
        transform.position += (Vector3.back * movespeed) * Time.deltaTime;
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        if(IsInView(viewportPos))
        {
            time_in_view += Time.deltaTime;
        }

        if(time_in_view > threshold)
        {
            ChangeColor(Color.green);
            ready_to_delete = true;
        }

        if(ready_to_delete && !deleted && time_script.timer_running)
        {
            if (Touchscreen.current != null)
            {
                if (Pointer.current.press.isPressed)
                {
                    deleted = true;
                    score_manager.AddScore();
                    play_sound = true;
                    Delete_ball();
                }
            }
        }


        if(transform.position.z < Camera.main.transform.position.z)
        {
            play_sound = false;
            Delete_ball();
        }
            
    }

    void Delete_ball()
    {
        if (play_sound)
        {
            Debug.Log("about to play audiosource clip");
            //if (audiosource.clip == null)
            //    Debug.Log("null audioclip");
            audiosource.volume = 0.01f;
            audiosource.Play();
            Destroy(gameObject, audiosource.clip.length);
            return;
        }
        Destroy(gameObject);        
    }

    bool IsInView(Vector3 viewport_pos)
    {
        if(viewport_pos.z > 0)
        {
            if(viewport_pos.x >=0 && viewport_pos.x <= 1)
            {
                if(viewport_pos.y >=0 && viewport_pos.y <= 1)
                {
                    return true;
                }
            }
        }

        return false;
    }

    void ChangeColor(Color new_colour)
    {
        BallRenderer.material.color = new_colour;
    }
}
