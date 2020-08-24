using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuggedMaterial : MonoBehaviour
{

    public List<GameObject> boxes;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            boxes.Add(transform.GetChild(i).gameObject);
            boxes[i].GetComponent<Renderer>().enabled = false;
            boxes[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //boxes[i].GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetBugged.bugged)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                boxes[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                boxes[i].GetComponent<Renderer>().enabled = true;
                boxes[i].GetComponent<Rigidbody>().isKinematic = false;
                boxes[i].GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}
