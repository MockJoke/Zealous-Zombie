using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zombie : MonoBehaviour
{

	float dirX;

	public int score, ZombieCount;

	Animator AnimatorZombie;

	public GameObject can;

	[SerializeField]
	float WalkSpeed = 2f;

	Rigidbody2D Zmb;

	bool facingRight = false;

	Vector3 localScale;

	void Start()
	{
		AnimatorZombie = GetComponent<Animator>();
		
		localScale = transform.localScale;
		Zmb = GetComponent<Rigidbody2D>();
		dirX = 1f;
	}

	// Update is called once per frame
	void Update()
	{
		Zmb.velocity = new Vector2(dirX * WalkSpeed, Zmb.velocity.y);
		
		CheckWhereToFace();

	}


	void CheckWhereToFace()
	{
		if (dirX > 0)
			facingRight = true;
		else if (dirX < 0)
			facingRight = false;

		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;

		transform.localScale = localScale;
	}
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "bullet")
		{
			AnimatorZombie.SetTrigger("Die");

			WalkSpeed = 0; 
			Zmb.velocity = Zmb.velocity = new Vector2(0, 0);

			this.gameObject.tag = "DeadZombie";

			score += 500;
			PlayerPrefs.SetInt("score", score); 

		}

		if (collision.gameObject.tag == "boundary")
		{
			dirX *= -1;
		}

	}

}
