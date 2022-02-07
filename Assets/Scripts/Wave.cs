using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float angleFromSub = 45.0f;
    public float distanceFromSub = 5.0f;
    int speed = 10;
    Vector3 travel_to;
    // (r, theta)
    // Start is called before the first frame update
    void Start()
    {
        //this.transform.Rotate(0, this.transform.rotation.y + angleFromSub, 0);
        float x = distanceFromSub * Mathf.Cos(angleFromSub);
        float y = distanceFromSub * Mathf.Sin(angleFromSub);
        Debug.Log("CartCoords are: (" + x + ", " + y + ")");
        float inv_x = distanceFromSub * Mathf.Cos(angleFromSub + 180);
        float inv_y = distanceFromSub * Mathf.Sin(angleFromSub + 180);

        travel_to.Set(inv_x, 0, inv_y);
        Vector3 startRotation = new Vector3(x, 0, y);
        this.transform.position = startRotation;
        this.transform.Rotate(0, angleFromSub, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position  = Vector3.MoveTowards(transform.position, travel_to, Time.deltaTime * speed);
    }
}
