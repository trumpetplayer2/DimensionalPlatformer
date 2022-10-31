using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D Player;
    public PowerUpType power;
    public float jumpPower = 8f;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isOnGround;
    private float inX = 0f;
    public bool canSwapLeft = false;
    public bool canSwapRight = false;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI Swaps;
    public TextMeshProUGUI AttemptsText;
    public TextMeshProUGUI PowerText;
    private static int attemptNumber = 1;
    public double baseScore = 100;
    public int generalTime = 60;
    private double swapTime = 0;

    private void Start()
    {
        AttemptsText.text = "Attempts: " + attemptNumber;
    }

    // Update is called once per frame
    void Update()
    {
        inX = Input.GetAxisRaw("Horizontal");
        if(Player.gameObject.GetComponent<SpriteRenderer>() != null)
        {
            Player.gameObject.GetComponent<SpriteRenderer>().color = power.color();
        }
        PowerText.text = "Ability: " + power.ToString();
    }

    private void FixedUpdate()
    {
        if(Time.timeScale <= 0) { return; }
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (Input.GetButton("Jump") && isOnGround)
        {
            Player.velocity = new Vector2(Player.velocity.x, jumpPower);
        }


        Vector2 moveX = new Vector2(inX * movementSpeed, Player.velocity.y);
        Player.velocity = moveX;

        //Power Up Handler
        switch (power)
        {
            case PowerUpType.PORTAL:
                portalPower();
                break;
            default: break;
        }
    }

    public PowerUpType GetPowerUp(){return power;}
    public void setPowerUp(PowerUpType newPower) { power = newPower; }

    private void portalPower()
    {
        //If there is no Dimension Handler, they can't switch dimensions
        if (Player.gameObject.GetComponent<DimensionHandler>() == null) { return; }
        if(!(Time.timeAsDouble > swapTime)) { return; }
        DimensionHandler dimension = Player.gameObject.GetComponent<DimensionHandler>();
        if (Input.GetAxisRaw("Dimension Switch") != 0)
        {
            //Grab direction to switch dimensions
            float direction = Input.GetAxisRaw("Dimension Switch");
            //If the dimension is not the first (0), allow switching back if direction is negative
            if(direction < 0 && dimension.currentDimension > 0 && canSwapLeft)
            {
                dimension.switchLocations(dimension.currentDimension - 1);
                swapTime = Time.timeAsDouble + 0.5;
            }else if(direction < 0 && canSwapLeft)
            {
                dimension.switchLocations(dimension.maxDimension);
                swapTime = Time.timeAsDouble + 0.5;
            }
            //Check if player is at the last dimension, if not, allow travel forward
            if(direction > 0 && dimension.currentDimension < dimension.maxDimension && canSwapRight)
            {
                dimension.switchLocations(dimension.currentDimension + 1);
                swapTime = Time.timeAsDouble + 0.5;
            }
            else if(direction > 0 && canSwapRight)
            {
                dimension.switchLocations(0);
                swapTime = Time.timeAsDouble + 0.5;
            }
        }
    }

    public void Reset()
    {
        attemptNumber += 1;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void calculateScore()
    {
        //Calculate score
        int TimeTaken = Int32.Parse(Timer.text.Substring(6).Trim());
        int SwapsUsed = Int32.Parse(Swaps.text.Substring(7).Trim());
        //Calculate Score
        double totalScore = power.powerMultiplier() * baseScore * generalTime / (TimeTaken + (5 * SwapsUsed));
        Score.text = "Score: " + Math.Round(totalScore);
        //Reset Attempts
        attemptNumber = 1;
    }
}
