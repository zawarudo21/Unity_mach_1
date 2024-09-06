using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ball_spawner_script : MonoBehaviour
{

    public GameObject moving_ball;
    public float spawnrate = 1f;
    public float range = 1000f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnrate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            int k = (int)(timer / spawnrate);
            //Debug.Log("value of timer, k, spawnrate " + $"{timer}" + "  " + $"{k}" + "   " + $"{spawnrate}");
            //int k = 10;
            for (int i = 0; i < k; i++)
            {
                SpawnBall();
            }
            timer = 0;
        }
    }

    void SpawnBall()
    {
        int range_x = Random.Range(-50, 50);
        int range_y = Random.Range(-20, 20);
        int range_z = Random.Range(0, 30);
        Vector3 random_offset = new Vector3(range_x, range_y, range_z);
        
        Vector3 offset = Random.insideUnitSphere * range;
        //Debug.Log("offset value " + offset);
        GameObject New_Moving_Ball =  Instantiate(moving_ball, transform.position + random_offset ,transform.rotation);
        Moving_Ball ball = New_Moving_Ball.GetComponent<Moving_Ball>();
        ball.movespeed = Random.Range(10, 25);
    }



}
