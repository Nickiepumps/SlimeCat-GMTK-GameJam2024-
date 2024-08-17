using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallexcontrol : MonoBehaviour
{
    private float startPos; //start position of backgrand
    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

    }
}
