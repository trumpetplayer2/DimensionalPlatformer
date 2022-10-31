using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    public PowerUpType powerUp = PowerUpType.PORTAL;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;
        //If collision is not player, then the game object doesn't matter
        if (!player.tag.Contains("Player")) { return; }
        //Check if player has controller
        if(player.GetComponent<PlayerController>() == null) { Debug.Log("Player touched power up but did not have player controller"); return; }
        //Define the controller and swap power up
        PlayerController controller = player.GetComponent<PlayerController>();
        controller.setPowerUp(powerUp);
        //This item has been consumed. Disable it.
        this.gameObject.SetActive(false);
    }
}
