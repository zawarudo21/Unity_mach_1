using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Button_click : MonoBehaviour
{

    public Ball_Prefab ballPrefab;
    public float interval = 1.0f;
    public float elapsed_time = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(" touchscreen value" + Touchscreen.current.press.isPressed);
        //bool is_pressed = Touchscreen.current.press.isPressed;
        if (Touchscreen.current != null)
        {
            //Debug.Log("Touchscreen pressed");
            if (Pointer.current.press.isPressed)
            {
                Debug.Log("Inside touchscreen pressed statement");
                Ball_Prefab ball = Instantiate<Ball_Prefab>(ballPrefab);
                ball.transform.localPosition = transform.position;
                ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * UnityEngine.Random.Range(500, 750));
            }
        }
        //elapsed_time += Time.deltaTime;
        //if (elapsed_time > interval)
        //{ 
        //    Debug.Log("Inside touchscreen pressed statement");
        //    Ball_Prefab ball = Instantiate<Ball_Prefab>(ballPrefab);
        //    ball.transform.localPosition = transform.position;
        //    ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * UnityEngine.Random.Range(500, 50000));
        //    elapsed_time -= interval;
        //}

    }
}
