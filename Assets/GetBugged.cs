using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GetBugged : MonoBehaviour
{

    public AudioSource sound;
    public GameObject player;
    public GameObject cam;
    public CharacterController cc;

    public Vector3 targetPosition;

    public bool position, direction;
    public static bool bugged = false;
    public static bool landed = false;

    void Start()
    {
        bugged = false;
        landed = false;
        transform.position += new Vector3(Random.Range(-18f, 18f), 0, Random.Range(-13.5f, 10f));
        transform.localEulerAngles += new Vector3(0, Random.Range(0f,360f), 0);
        cc.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (!sound.isPlaying)
        {
            sound.Play();
        }

        //if player is in place and looking
        if (!bugged && (Vector3.Distance(player.transform.position, targetPosition)) <= 1f/* &&  && (Mathf.Abs(transform.localEulerAngles.y) < 1f)*/)
        {
            position = true;
        }
        else
        {
            position = false;
        }

        if (Vector3.Distance(player.transform.position, targetPosition) <= 3f)
        {
            if (!Input.anyKey)
            {
                Vector3 diff = transform.position - targetPosition;
                cc.SimpleMove(-diff);
            }
        }

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit, 10))
        {
            Debug.Log(hit.collider.name);
            if(hit.collider.name == "bug")
            {
                direction = true;
            }
            else
            {
                direction = false;
            }

        }

        if(direction && position)
        {
            print("UR BUGGED");
            bugged = true;
            sound.pitch = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(transform.position.y <= -1000)
        {
            landed = true;
        }

    }
}
