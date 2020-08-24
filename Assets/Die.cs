using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public float attrition;
    public bool revived;
    public AudioSource death;
 
    // Start is called before the first frame update
    void Start()
    {
        attrition = Random.Range(.1f, 5f);
        death = GameObject.Find("CubeS").GetComponent<AudioSource>();  
        //transform.localScale = Vector3.Lerp(transform.localScale, 5* Vector3.one, Time.deltaTime * attrition);     
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, 3* Vector3.one, Time.deltaTime * attrition);
        if(transform.position.y <= -1100f)
        {
            Destroy(this.gameObject);
        }

      
    }

    void OnCollisionEnter(Collision collision)
    {
        if (GetBugged.landed)
        {
            if(Random.Range(0f, 1f) < 0.1f)
            {

                death.Play();
                Destroy(this.gameObject);
            }
        }
    }
}
