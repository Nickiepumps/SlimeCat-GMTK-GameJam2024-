using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    #region variable
    public bool canMove;
    public bool haveFuse;

    [Header("waypoints")]
    [SerializeField] float eSpeed = 1;
    [SerializeField] int wayPointStart;
    [SerializeField] Transform[] points;
    public PlayerMovement playerhello;

    [Header("idk")]
    public Fuse fuse;
    bool playerOnElevator;
    bool reverse;
    #endregion

    #region start && update
    private void Start()
    {
        transform.position = points[wayPointStart].position;
        //currentPointIndex = wayPointStart;
    }

    private void Update()
    {
        elevatorMove();
        elevatorMove2();
    }
    #endregion

    #region elevator move
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(hello());
        if (collision.CompareTag("Player"))
        {
            playerOnElevator = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnElevator = false;
            fuse.overWeight = false;
        }
    }

    private void elevatorMove()
    {
        // น้ำหนัก
        if(canMove == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[1].transform.position, eSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, points[1].position) < 0.01f)
            {
                canMove = false; // หยุดลิฟต์เมื่อถึง points[1]
            }
        }
    }
    private void elevatorMove2()
    {
        // ไฟฟ้า
        {
            if (fuse.completeFuse)
            {
                haveFuse = true;
            }
            else
            {
                haveFuse = false;
            }

            if (haveFuse)
            {
                if(reverse)
                {
                    transform.position = Vector2.MoveTowards(transform.position, points[0].position, eSpeed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, points[0].position) < 0.01f)
                    {
                        reverse = false;
                    }
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, points[1].position, eSpeed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, points[1].position) < 0.01f)
                    {
                        reverse = true;
                    }
                }
                if (playerhello.playerSize >= 2 && playerOnElevator)
                {
                    haveFuse = false;
                    fuse.overWeight = true;
                }
            }
        }
    }
    IEnumerator hello()
    {
        if (playerhello.playerSize >= 2 && haveFuse == false)
        {
            yield return new WaitForSeconds(0.5f);
            canMove = true;
        }
    }
    #endregion 
}