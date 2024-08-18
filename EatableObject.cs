using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatableObject : MonoBehaviour
{
    public Sprite itemSprite; // Item sprite for player inventory
    private PlayerMovement player; // Player gameObject
    private PlayerInventory playerInventory; // Player Inventory
    private bool isPlayerHitEatObj;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerInventory = GameObject.FindGameObjectWithTag("Manager").GetComponentInChildren<PlayerInventory>();
    }
    private void Update()
    {
        if(isPlayerHitEatObj == true)
        {
            EatObject();
        }
    }
    private void EatObject()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInventory.foodCount < 3)
        {      
            player.isEating = true;
            playerInventory.itemLists.Add(gameObject);
            playerInventory.inventorySlotLists[playerInventory.foodCount].gameObject.SetActive(true);
            playerInventory.inventorySlotLists[playerInventory.foodCount].transform.GetChild(0).GetComponentInChildren<Image>().sprite = itemSprite;
            isPlayerHitEatObj = false;
            playerInventory.foodCount++;
            player.playerSize++;
            gameObject.SetActive(false);

            player.walkSpeed = player.walkSpeed - 0.8f;
            player.jumpForce = player.jumpForce - 10;
            player.dashForce = player.dashForce - 10;
            Debug.Log("Eat up!");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerHitEatObj = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerHitEatObj = false;
        }
    }
}
