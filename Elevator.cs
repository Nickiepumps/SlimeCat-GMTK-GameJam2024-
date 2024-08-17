using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public bool canMove;

    [Header("waypoints")]
    [SerializeField] float eSpeed = 1;
    [SerializeField] int wayPointStart;
    [SerializeField] Transform[] points;
    public PlayerMovement playerhello;

    [Header("weight")]
    [SerializeField] int eWeight;

    [Header("idk")]
    int i;
    bool reverse;


    private void Start()
    {
        transform.position = points[wayPointStart].position;
    }
    private void Update()   
    {
        if(Vector2.Distance(transform.position, points[i].position) < 0.01f)
        {
            canMove = false;
            if(i == points.Length - 1) 
            {
                reverse = true;
                i--;
                return;
            } else if (i == 0)
            {
                reverse = true;
                i++;
                return;
            }
            
            if (reverse)
            {
                i--;
            }
            else
            {
                i++;
            }
        }

        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, eSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(hello());
    }

    IEnumerator hello()
    {
        if(playerhello.playerSize >= 2)
        {
            yield return new WaitForSeconds(0.5f);
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            canMove = false;
        }
    }
}
