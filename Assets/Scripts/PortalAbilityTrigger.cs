using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAbilityTrigger : MonoBehaviour
{
    public int id = 0;
    public bool canTeleport = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canTeleport = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canTeleport = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTeleport = true;
    }

    private void Update()
    {
        GameObject player = this.transform.parent.gameObject;
        if(player.GetComponent<PlayerController>() == null) { return; }
        PlayerController controller = player.GetComponent<PlayerController>();
        switch (id)
        {
            case 0:
                controller.canSwapLeft = canTeleport;
                break;
            case 1:
                controller.canSwapRight = canTeleport;
                break;
            default: break;
        }
    }
}
