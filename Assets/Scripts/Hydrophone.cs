using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class Hydrophone : MonoBehaviour
{
    // Speed of sound in water
    public float sound_speed_water = 1480f;
    public GameObject pinger;
    public int uid = 0;
    private Stopwatch timer;

    private float time_away;

    //only used to set up hydrophones locations s
    private GameObject hydrophones;
    private bool init_hydrophone = false;
    public float spawn_distance = 0;
    private long time_elapse_milisec;
    private bool got = false;
    private bool toggle = true;

    void Awake()
    {
        timer = new Stopwatch();
        timer.Start();

        if (init_hydrophone)
            SpawnHydrophones();
        //For now, calculates time using the speed of sound in water divded by the distance from 
        //time_away = CalculateTime();
        //Debug.Log("Time away from " + this.ToString() + " is " + time_away);

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Wave
        if (other.tag == "Wave")
        {
            Debug.Log("Triggered by wave");
            timer.Stop();
            time_elapse_milisec = timer.ElapsedMilliseconds;
            long time_elapse_sec = time_elapse_milisec * 1000;
            Debug.Log(time_elapse_sec + " Secs have passed");
            got = true;
        }
        else
        {
            Debug.Log("other tag is " + other.tag);
        }
    }

    //float CalculateTime()
    //{
    // float distance = Vector3.Distance(this.transform.position, pinger.transform.position);
    // Debug.Log(this + " is " + distance + " away from " + pinger);
    // return distance / sound_speed_water;S

    // }
    public bool GetGot()
    {
        return got;
    }

    public bool ToggleGot()
    {
        if(toggle && got)
        {
            toggle = false;
            got = false;
            return true;
        }

        return false;
    }

    public long GetTimeElapseMilisec()
    {
        return time_elapse_milisec;
    }

    void SpawnHydrophones()
    {
        float x = spawn_distance * Mathf.Cos(300 * Mathf.Deg2Rad);
        float z = spawn_distance * Mathf.Sin(300 * Mathf.Deg2Rad);
        Instantiate(hydrophones, new Vector3(x, 0, z), Quaternion.identity);

        float x2 = spawn_distance * Mathf.Cos(240 * Mathf.Deg2Rad);
        float z2 = spawn_distance * Mathf.Sin(240 * Mathf.Deg2Rad);
        Instantiate(hydrophones, new Vector3(x2, 0, z2), Quaternion.identity);
        init_hydrophone = false;
    }
}
