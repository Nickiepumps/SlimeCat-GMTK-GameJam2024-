using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    float playerInputX;
    float playerInputY;
    float moveUp;
    public float speed;
    public tubeTrail trail;//use trail from tubetrail script

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        playerInputX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        playerInputY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        moveUp = playerInputY;
        transform.Translate(playerInputX , playerInputY, 0);
        if(playerInputX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if(playerInputX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if(playerInputY > 0)
        {
            playerInputX = playerInputY;
            transform.localScale = new Vector3(1, 1, 1);
            //transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        if(playerInputY < 0)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        if(playerInputX != 0 || playerInputY != 0)
        {
            trail.makeTrail = true;
        }
        else
        {
            trail.makeTrail = false;
        } */
        get_input();
    }
    void get_input()
    {
        playerInputX = speed * Time.deltaTime;
        playerInputY = speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
            transform.Translate(playerInputY, 0, 0);
            trail.makeTrail = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 270));
            transform.Translate(playerInputY, 0, 0);
            trail.makeTrail = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
            transform.Translate(playerInputX, 0, 0);
            trail.makeTrail = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.Translate(playerInputX, 0, 0);
            trail.makeTrail = true;
        }
        else
        {
            trail.makeTrail = false;
        }

    }
}
