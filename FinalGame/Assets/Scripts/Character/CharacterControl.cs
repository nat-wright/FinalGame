using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

	public CharacterController characterController;
	public static bool gameOver;
	public float gravity = 9.81f;
	public float speed = 10;
	public Vector3 moveVector3;
	public float jumpForce = 20;
    public Sprite Stand;
	public Sprite Walk;
	public Sprite Jump;
	public SpriteRenderer mySprite;


//Character can move
	void Update () {
		moveVector3.y -= gravity * Time.deltaTime;

		if (characterController.isGrounded && !gameOver)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				moveVector3.y = jumpForce * Time.deltaTime;
			}
			
			moveVector3.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		}
		characterController.Move(moveVector3);

//Sprite switch
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
		{
			mySprite.sprite = Walk;
		}else  
			mySprite.sprite = Stand;

        if (Input.GetKey(KeyCode.Space))
        {
			mySprite.sprite =  Jump;
        }
	}
}