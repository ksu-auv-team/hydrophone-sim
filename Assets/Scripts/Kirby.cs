using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Kirby : MonoBehaviour
{
    List<long> hydrophone_times = new List<long>();
    Dictionary<int, long> hydrophone = new Dictionary<int, long>();
    float rotation_degreeeeeee = 0;

    // Start is called before the first frame update
    void Start()
    {
        //rotation_degreeeeeee = internet_math(hydrophone_times);
        //Debug.Log("rotation angle is " + rotation_degreeeeeee)
        //this.transform.Rotate(0, this.transform.rotation.y + rotation_degreeeeeee, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (hydrophone_times.Count < 3)
        {
            //Debug.Log("Hydro count " + hydrophone_times.Count);
            int i = 0;
            //Debug.Log("in that if");
            foreach (Transform child in transform)
            {
                if (child.gameObject.tag == "Hydrophone")
                {
                    // Adds the time_away from each child gameObject to the list
                    if (child.gameObject.GetComponent<Hydrophone>().GetGot() && child.gameObject.GetComponent<Hydrophone>().ToggleGot())
                    {
                        Debug.Log("TRUE");
                        long time_ms = child.gameObject.GetComponent<Hydrophone>().GetTimeElapseMilisec();
                        int uid = child.gameObject.GetComponent<Hydrophone>().uid;
                        hydrophone_times.Add(time_ms);
                        GameObject test = child.gameObject;
                        Debug.Log("uid " + uid + " time_ms " + time_ms);
                        hydrophone.Add(uid, time_ms);
                        Debug.Log("hydro count " + hydrophone.Count);
                        //child.gameObject.
                    }
                    else
                    {
                        i++;
                        //Debug.Log("(" + i + ") size of bool list is: " + hydrophone_times.Count);
                    }
                }
            }

        } //endif hydrophone_times > 3
        else
        {
            //Debug.Log("we gottem bois ");


        }
           
        /*float foo = this.transform.eulerAngles.y - rotation_degreeeeeee;
        if (Vector3.Distance()
        {
           Debug.Log("FOOOOO " + foo);
           this.transform.Rotate(0, -rotation_degreeeeeee * Time.deltaTime, 0);
        }*/
        /*
        if (Input.GetKeyDown("space")) {
            this.transform.Rotate(0, this.transform.rotation.y + 30, 0);
        }*/
    }

    Dictionary<int, long> sort_hydros()
    {
        //      List<GameObject> temp = new List<GameObject>;
        //hydrophone.
        Dictionary<int, long> ordered = new Dictionary<int, long>();
        ordered = hydrophone.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        foreach (KeyValuePair<int, long> kvp in ordered)
        {
            //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            Debug.Log("Key = " + kvp.Key + " Value = " + kvp.Value);
        }
        return ordered;
    }

    float Getdegreeeeeee(List<long> hp_list)
    {
        // Orders the list of times from smallest to largest
        hp_list.Sort();

        // Getting time differences
        float time_initial = hp_list[0];
        float time_mid = hp_list[1] - time_initial;
        float time_final = hp_list[2] - time_initial;
        float time_final_minus_time_mid_RAW = (hp_list[2] - hp_list[1]);
        Debug.Log("\ninit " + hp_list[0] + " middle: " + hp_list[1] + " final: " + hp_list[2]);
        Debug.Log("\nTIME DIFFERENECES: init " + 0 + " middle: " + time_mid + " final: " + time_final);


        /*float numerator = Mathf.Sqrt(3f) + (1 + (time_mid / time_final));
         float denominator = 3 * (1 - (time_mid / time_final));
         float degreeeeeee = Mathf.Atan(numerator / denominator) * Mathf.Rad2Deg;
        */
        float rho = time_final / (hp_list[2] - hp_list[1]);
        float numerator = Mathf.Sqrt(3f);
        float denominator = (2 * rho) - 1;

        float formula = Mathf.Atan(numerator / denominator);
        float degreeeeeee;

        if (time_final > (0.5 * time_final_minus_time_mid_RAW) && time_final_minus_time_mid_RAW != 0)
            degreeeeeee = formula;
        else if (time_final > (0.5 * time_final_minus_time_mid_RAW) && time_final_minus_time_mid_RAW != 0)
            degreeeeeee = formula + Mathf.PI;
        else if (hp_list[2] == hp_list[1] && hp_list[2] > hp_list[0])
            degreeeeeee = (Mathf.PI * 0.5f);
        else if (hp_list[2] == hp_list[1] && hp_list[2] < hp_list[0])
            degreeeeeee = -((Mathf.PI * 0.5f));
        else if (time_final == (0.5 * time_final_minus_time_mid_RAW) && hp_list[2] >= hp_list[0])
            degreeeeeee = 0f;
        else if (time_final == (0.5 * time_final_minus_time_mid_RAW) && hp_list[2] < hp_list[0])
            degreeeeeee = Mathf.PI;
        else
            degreeeeeee = formula;


            Debug.Log("degreeeeeee to turn is " + degreeeeeee * Mathf.Rad2Deg + " degreeeeeee");
        return degreeeeeee * Mathf.Rad2Deg;

    }

    float michael_math(List<long> hp_list)
    {
        /*
        // Orders the list of times from smallest to largest
        hp_list.Sort();

        float time_initial = hp_list[0];
        float time_mid = hp_list[1] - time_initial;
        float time_final = hp_list[2] - time_initial;

        float degree = 0f;
        
        if(time_mid == 0)
        {
            degree = 45;
        }
        else if (time_final == time_mid)
        {
            degree = 0;
        }
        else if (time_final == 0)
        {
            degree = 315;
        }
        else if (time_final != time_mid)
        {
            //degree = MAAATTTHH;
        }
        //else if ()
        */
        return 1.0f;

    }

    float internet_math(List<long> hp_list)
    {
        /*
        // Orders the list of times from smallest to largest
        float rotation_degree = 0;

        hp_list.Sort();

        // Getting time differences
        float time_initial = hp_list[0];
        float time_mid = hp_list[1] - time_initial;
        float time_final = hp_list[2] - time_initial;
        float time_final_minus_time_mid_RAW = (hp_list[2] - hp_list[1]);


        Debug.Log("\ninit " + hp_list[0] + " middle: " + hp_list[1] + " final: " + hp_list[2]);
        Debug.Log("\nTIME DIFFERENECES: init " + 0 + " middle: " + time_mid + " final: " + time_final);

        float numerator = Mathf.Sqrt(3f);
        float rho = time_final / (hp_list[2] - hp_list[1]);
        float denominator = (2 * rho) - 1;
        float formula = Mathf.Atan(numerator / denominator);

        if((time_final  > (0.5f) * (time_final - time_mid)) && ((time_final - time_mid) != 0))
        {
            rotation_degree = formula;
            Debug.Log("formula");
        }
        else if ((time_final < ((.5f) * (time_final - time_mid))) && ((time_final - time_mid) != 0))
        {
            rotation_degree = formula + Mathf.PI;
            Debug.Log("formula + PI");
        }
        else if (time_final == time_mid && time_final > time_initial)
        {
            rotation_degree = (Mathf.PI * 0.5f);
            Debug.Log("pi/2");
        }
        else if (time_final == time_mid && time_initial > time_final)
        {
            rotation_degree = -(Mathf.PI * 0.5f);
            Debug.Log("- pi/2");
        }
        else if (((time_final) == ((0.5f) * (time_final -time_mid))) && (time_final >= time_initial))
        {
            rotation_degree = 0;
            Debug.Log("0");
        }
        else if (((time_final) == ((0.5f) * (time_final - time_mid))) && (time_initial > time_final))
        {
            rotation_degree = Mathf.PI;
            Debug.Log("pi");

        }
        */

        return 0; // rotation_degree * Mathf.Rad2Deg;
    }

}
