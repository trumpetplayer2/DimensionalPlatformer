using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DimensionHandler : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public int currentDimension = 0;
    public int maxDimension = 1;
    public GameObject player;
    public int timesSwapped = 0;
    public TextMeshProUGUI[] SwapCounters;
    public void Start()
    {
        switch (currentDimension)
        {
            case 0:
                camera1.enabled = true;
                camera2.enabled = false;
                break;
            case 1:
                camera1.enabled = false;
                camera2.enabled = true;
                break;
        }
        }
    public void Update()
    {
        foreach(TextMeshProUGUI gui in SwapCounters)
        {
            gui.text = "Swaps: " + timesSwapped;
        }
    }
    public void switchLocations(int newLocation)
    {
        Vector3 v = player.transform.position;
        if(newLocation < currentDimension)
        {
            camera1.enabled = true;
            camera2.enabled = false;
            v.x -= 30;
            player.transform.position = v;
        }
        else
        {
            camera1.enabled = false;
            camera2.enabled = true;
            v.x += 30;
            player.transform.position = v;
        }
        currentDimension = newLocation;
        timesSwapped += 1;
    }
}
