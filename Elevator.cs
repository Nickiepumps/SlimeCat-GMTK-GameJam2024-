using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    #region variable
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
    #endregion

    #region start && update
    private void Start()
    {
        transform.position = points[wayPointStart].position;
    }

    private void Update()
    {
        elevatorMove();
    }
    #endregion

    #region elevator move
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(hello());
    }

    private void elevatorMove()
    {
        if(canMove == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[1].transform.position, eSpeed * Time.deltaTime);
        }
        /*if (Vector2.Distance(transform.position, points[i].position) < 0.01f)
        {
            canMove = false; //ถ้าไม่มีโค้ดบรรทัดนี้หลังจาก player โดน collision ของ elevator ตัว elevator จะทำงานเรื่อยๆ
            if (i == points.Length - 1)
            {
                reverse = true;
                i--;
                return;
            }
            else if (i == 0)
            {
                reverse = true;
                i++;
                //canMove = false; //ถ้าเอา canMove = false มาไว้บรรทัดล่าง i++ หลังจาก player โดน collision ของ elevator ตัว elevator จะลงไปที่ waypoints B และกลับมาที่ waypoints A อีกครั้ง
                return;
            }
        }

        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, eSpeed * Time.deltaTime);
        }*/
    }
    IEnumerator hello()
    {
        if (playerhello.playerSize >= 2)
        {
            yield return new WaitForSeconds(0.5f);
            canMove = true;
        }
    }
    #endregion 
}