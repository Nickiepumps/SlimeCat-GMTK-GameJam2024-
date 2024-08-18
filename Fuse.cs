using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fuse : MonoBehaviour
{
    #region variable
    public bool completeFuse;

    [Header("Fuse")]
    [SerializeField] List<int> numberFuse;
    public Elevator elevator;
    #endregion

    #region completeFuse
    private void Update()
    {
        if (numberFuse.Count == 2)
        {
            completeFuse = true;
            elevator.haveFuse = true;
        }
        else
        {
            completeFuse = false;
        }
    }
    #endregion
}
