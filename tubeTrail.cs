using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tubeTrail : MonoBehaviour
{
    public float trailDelay;
    private float trailDelaySeconds;
    public GameObject trail;
    public bool makeTrail = false;
    public GameObject trailPosition;
    public float destroyTrail;
    // Start is called before the first frame update
    void Start()
    {
        trailDelaySeconds = trailDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (makeTrail)
        {
            if (trailDelaySeconds > 0)
            {
                trailDelaySeconds -= Time.deltaTime;
            }
            else
            {
                GameObject currentTrail = Instantiate(trail, trailPosition.transform.position, transform.rotation);
                //Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;
                currentTrail.transform.localScale = this.transform.localScale;
                //currentTrail.GetComponent<SpriteRenderer>().sprite = currentSprite;
                trailDelaySeconds = trailDelay;
                Destroy(currentTrail, destroyTrail);
            }
        }
        
    }
}
