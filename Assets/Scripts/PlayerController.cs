using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;


public class PlayerController : MonoBehaviour
{

    public Vector2 moveValue;
    public float speed;
    private int count;
    private int numPickups = 3; //number of pickups we have
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI playerPosition;
    public TextMeshProUGUI playerVelocity;
    private Vector3 oldPosition;
    private Vector3 velocity;


    void Start()
    {
        count = 0;
        winText.text = "";
        SetCountText();
        SetPlayerPositionText();
        SetPlayerVelocityText();
        oldPosition = transform.position;
    }
    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
        velocity = (transform.position - oldPosition) / Time.deltaTime;

        SetPlayerPositionText();
        SetPlayerVelocityText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString();
        if (count >= numPickups)
        {
            winText.text = "You win!";
        }

    }

    private void SetPlayerPositionText()
    {
        playerPosition.text = "Position: " + transform.position.ToString();
    }

    private void SetPlayerVelocityText(){
        playerVelocity.text = "Velocity: " + velocity.magnitude.ToString();

    }



}
