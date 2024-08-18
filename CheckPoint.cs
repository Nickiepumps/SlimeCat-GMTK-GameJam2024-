using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Transform checkpoint; // จุด Checkpoint ที่กำหนด
    [SerializeField] private GameObject respawnTrigger; // วัตถุที่ถ้าชนแล้วจะกลับไปที่ Checkpoint

    private Vector3 checkpointPosition;

    private void Start()
    {
        checkpointPosition = checkpoint.position; // เริ่มต้นที่ Checkpoint ที่กำหนด
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่าชนกับวัตถุที่กำหนดหรือไม่
        if (other.gameObject == respawnTrigger)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = checkpointPosition; // ย้ายผู้เล่นกลับไปที่จุด Checkpoint
        GetComponent<Rigidbody2D>().velocity = Vector2.zero; // รีเซ็ตความเร็วของผู้เล่น
    }
}