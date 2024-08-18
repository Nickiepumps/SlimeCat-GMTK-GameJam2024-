using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    #region variable
    public bool doorHaveFuse;

    [Header("fuse")]
    public Fuse fuse;
    #endregion
    private void Update()
    {
        doorOpen();
    }

    private void doorOpen()
    {
        if (fuse.completeFuseDoor)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
