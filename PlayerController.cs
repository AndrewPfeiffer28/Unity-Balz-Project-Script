using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public int count = 0;
    public GameObject winTextObject;
    public GameObject ReturnToMenu;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public PlayerController playerController;

    public int Count
    {
        get { return count; }

        set { count = value; }
    }

    public void ResetCount()
    {
        count = 0;
        SetCountText();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Count = 0;
        SetCountText();

        // set canvas objects initially as hidden
        winTextObject.SetActive(false);
        ReturnToMenu.SetActive(false);
        
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        // does the actuall spacebar jumping
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    bool IsGrounded()  
    {
        // checks to see if the player is touching the ground or an object
        float raycastDistance = 0.7f;
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance);
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

        // Function Body for computer instruction
    }

    void SetCountText()
    {
        countText.text = "Count: " + Count.ToString();
        if (Count == 11)
        {
            // makes the win text active for the player
            winTextObject.SetActive(true);
            ReturnToMenu.SetActive(true);
            Time.timeScale = 0;
        }

    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            // this diables the object the player touches without destoying it
            other.gameObject.SetActive(false);
            Count++;
            // updates the text editor **aparently**
            SetCountText();
        }
        
    }
}
