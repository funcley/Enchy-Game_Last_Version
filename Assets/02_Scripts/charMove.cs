using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class charMove : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public float timeStart;
    public TMP_Text textBox;
    
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
       
    }

    void Update()
    {
        timeStart += Time.deltaTime;
        //textBox.text = timeStart.ToString("F0");
        Debug.Log(textBox.text);
        int minutes = Mathf.FloorToInt(timeStart / 60);
        int seconds = Mathf.FloorToInt(timeStart - minutes * 60f);
        textBox.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        
        groundedPlayer = controller.isGrounded;
       
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            SoundManager.Instance.PlaySound(SoundType.TypeJump);
            
            
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}