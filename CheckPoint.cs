using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // วัตถุที่ผู้เล่นต้องชน
    [SerializeField] private GameObject collisionObject;

    // จุด checkpoint ที่ผู้เล่นจะกลับไปเมื่อชน
    [SerializeField] private Transform checkpoint;

    // AudioSource สำหรับเล่นเพลง
    [SerializeField] private AudioSource audioSource;

    // ตัวควบคุมการเคลื่อนที่ของผู้เล่น
    private Rigidbody2D playerRigidbody;
    private bool canMove = true;  // ใช้ในการควบคุมว่าผู้เล่นสามารถเคลื่อนที่ได้หรือไม่

    private void Start()
    {
        // เล่นเพลงเมื่อเริ่ม Scene
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // รับค่า Rigidbody2D ของผู้เล่น
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // ตรวจสอบว่าผู้เล่นสามารถเคลื่อนที่ได้หรือไม่
        if (canMove)
        {
            // ตัวอย่างโค้ดสำหรับการควบคุมการเคลื่อนที่ของผู้เล่น
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveX, moveY);
            playerRigidbody.velocity = movement * 5f; // กำหนดความเร็วในการเคลื่อนที่
        }
        else
        {
            // ถ้าหากไม่สามารถเคลื่อนที่ได้ ให้หยุดการเคลื่อนที่
            playerRigidbody.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == collisionObject)
        {
            // หยุดเพลงชั่วคราว
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Pause();
            }

            // เรียกใช้ Coroutine เพื่อหยุดผู้เล่นชั่วคราว
            StartCoroutine(FreezePlayerAndReset());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == collisionObject)
        {
            // หยุดเพลงชั่วคราว
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Pause();
            }

            // เรียกใช้ Coroutine เพื่อหยุดผู้เล่นชั่วคราว
            StartCoroutine(FreezePlayerAndReset());
        }
    }

    // Coroutine สำหรับหยุดผู้เล่นชั่วคราวก่อนที่จะย้ายไปยัง checkpoint
    private IEnumerator FreezePlayerAndReset()
    {
        // หยุดการเคลื่อนที่ของผู้เล่น
        canMove = false;

        // Freeze ตำแหน่งของผู้เล่น แต่ยังล็อคการหมุนไว้
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

        // รอ 3 วินาที
        yield return new WaitForSeconds(3f);

        // ย้ายผู้เล่นกลับไปที่ checkpoint
        transform.position = checkpoint.position;

        // ปลดล็อคตำแหน่งของผู้เล่น แต่ยังคงล็อคการหมุนไว้
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        // เล่นเพลงต่อจากจุดที่หยุด
        if (audioSource != null)
        {
            audioSource.UnPause();
        }

        // ให้ผู้เล่นเคลื่อนที่ได้อีกครั้ง
        canMove = true;
    }
}