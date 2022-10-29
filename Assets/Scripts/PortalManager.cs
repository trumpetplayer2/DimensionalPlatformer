using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public int newDimensionID;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<DimensionHandler>() == null) { return; }
        DimensionHandler handler = collision.gameObject.GetComponent<DimensionHandler>();
        if (handler.currentDimension != newDimensionID)
        {
            handler.switchLocations(newDimensionID);
        }
    }
}
