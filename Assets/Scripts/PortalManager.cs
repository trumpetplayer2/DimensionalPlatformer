using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public int newDimensionID;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<DimensionHandler>() == null) { Debug.Log(collision.gameObject.ToString() + " was not a valid object"); return; }
        DimensionHandler handler = collision.gameObject.GetComponent<DimensionHandler>();
        if (handler.currentDimension != newDimensionID)
        {
            handler.switchLocations(newDimensionID);
            handler.currentDimension = newDimensionID;
        }
    }
}
