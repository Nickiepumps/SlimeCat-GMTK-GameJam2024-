using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fuse : MonoBehaviour
{
    #region variable
    public bool completeFuse;
    public bool completeFuseDoor;
    public bool overWeight;

    [Header("Fuse")]
    [SerializeField] List<int> numberFuse;
    public Elevator elevator;
    #endregion

    #region completeFuse
    private void Update()
    {
        if (numberFuse.Count >= 1 && overWeight == false)
        {
            completeFuse = true;
            elevator.haveFuse = true;
        }
        else
        {
            completeFuse = false;
        }

        if (numberFuse.Count == 2)
        {
            completeFuseDoor = true;
        }
        else
        {
            completeFuseDoor = false;
        }
    }
    #endregion
}
