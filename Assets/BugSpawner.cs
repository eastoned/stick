using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject bug;
    public List<GameObject> bugs;
    public int counter;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0 ; i < counter; i++)
        {
            GameObject clone = Instantiate(bug, new Vector3(Random.Range(-18.5f, 18.5f), Random.Range(0.5f, 10f), Random.Range(-14.5f, 15.5f)), Random.rotation);
            bugs.Add(clone);
            clone.transform.localScale = new Vector3(Random.Range(0.1f, 2f), Random.Range(0.1f, 0.3f), Random.Range(0.1f, 0.3f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= .85f)
        {
            Destroy(bugs[bugs.Count-1]);
            bugs.Remove(bugs[bugs.Count-1]);
            timer = 0;
        }

        if (GetBugged.bugged)
        {
            for(int i = 0; i < bugs.Count; i++)
            {
                Destroy(bugs[i]);
            }
            Destroy(bug);
            Destroy(this.gameObject);
        }
    }
}
