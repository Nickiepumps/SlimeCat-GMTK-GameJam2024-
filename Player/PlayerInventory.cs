using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    private PlayerMovement player;
    public List<GameObject> itemLists; // Player eatable object lists
    public List<Image> inventorySlotLists; // Player inventory slot lists 
    public int foodCount = 0;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if(player.isPuke == true)
        {
            inventorySlotLists[foodCount].gameObject.SetActive(false);
        }
    }
}
