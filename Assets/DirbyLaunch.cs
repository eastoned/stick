using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirbyLaunch : MonoBehaviour
{

    public GameObject dirb;
    public float timer;

    void Update()
    {


        if (GetBugged.bugged)
        {
            timer += Time.deltaTime;
        }

        if (GetBugged.bugged && (Time.time%2 >= 1f) && !GetBugged.landed)
        {
            for(int i =0;i< 60; i++) {
                Rigidbody bull = Instantiate(dirb, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                bull.AddForce(new Vector3(0, 1f, -15f), ForceMode.Impulse);
            }

            timer = 0;
        }

    }

}
