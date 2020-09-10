using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	
	[SerializeField] private bool m_AirControl = false;							
	[SerializeField] private LayerMask m_WhatIsGround;							
	[SerializeField] private Transform m_GroundCheck;

	public Transform gameCheckPoint;
	public AudioSource[] deathSounds;
	public AudioSource jumpSound;

	public int jumpCounter = 0;

	const float k_GroundedRadius = .1f; 

	private Rigidbody2D rb2D;
	private bool m_FacingRight = true;  

	private void Awake()
	{
		Physics2D.IgnoreLayerCollision(8, 13);

		rb2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{

		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				jumpCounter = 0;
			}
			if (colliders[i].gameObject.GetComponent <Killable>() != null)
            {
				rb2D.velocity = new Vector2(rb2D.velocity.x, m_JumpForce/1.5f);
				AudioSource killSound = GameObject.FindGameObjectWithTag("KillSound").GetComponent<AudioSource>();
				killSound.Play();
				Destroy(colliders[i].gameObject);
            }
		}
	}

    private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<DeathPart>() != null)
		{
			gameOver();
		}
	}

    public void gameOver()
	{
		transform.position = gameCheckPoint.position;
		int randomDth = Random.Range(0, deathSounds.Length);
		deathSounds[randomDth].Play();
		GameManager.singleton.showGameOver();
	}


	public void Move(float move, bool jump){
		Vector3 targetVelocity = new Vector2(move * 10f, rb2D.velocity.y);
		rb2D.velocity = targetVelocity;

		if (move > 0 && !m_FacingRight)	Flip();
		else if (move < 0 && m_FacingRight) Flip();

		if (jump && jumpCounter<2){
			jumpCounter += 1;
			jumpSound.Play();
			rb2D.velocity = new Vector2(rb2D.velocity.x, m_JumpForce);			
		}
	}
	                 

	private void Flip(){
		m_FacingRight = !m_FacingRight;
		transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
	}
}
