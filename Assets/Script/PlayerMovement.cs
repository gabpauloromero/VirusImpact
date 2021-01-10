using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb2d;
	public float speed;
	public float movement;
	public float jumpforce = 5f;
	public Transform groundpoint;
	public float groundradius;
	public LayerMask groundLayer;
	public Transform overheadpoint;
	public float overheadradius;
	public bool onGround;
	bool crouchstat;
	public Vector3 spawnpoint;
	public CapsuleCollider2D playercollider;
	Animator moveanim;
	public int bullettotal;
	public Text bullets;
	public Text score;
	public float delaytime;
	public int totalscore;
	SpriteRenderer spriteRend;
	string playertag;
	bool ice;
	public GameObject textfield;
	public float totaltime;
	public bool bestscorename;
	public bool besttimename;


	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		moveanim = GetComponent<Animator> ();
		spawnpoint = transform.position;
		delaytime = 0;
		spriteRend = GetComponent<SpriteRenderer> ();
		bullettotal = PlayerPrefs.GetInt ("Totalbullet");
		totalscore = PlayerPrefs.GetInt ("Score");
		PlayerPrefs.SetString ("Stop", "no");
		playertag = gameObject.tag;
		bool ice = false;
		bestscorename = false;
		besttimename = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		bullets.text = bullettotal.ToString();
		score.text = totalscore.ToString();
			
		if (delaytime > 0 && gameObject.tag == "invul") 
		{
			delaytime -= Time.deltaTime;
			if (delaytime <= 0) 
			{	
				if (spriteRend != null) 
				{	
					spriteRend.enabled = true;
					gameObject.tag = playertag;
				}
			}
			else
			{
				if (spriteRend != null) 
				{	
					spriteRend.enabled = !spriteRend.enabled;
				}
			}
		}

		onGround = Physics2D.OverlapCircle (groundpoint.position, groundradius, groundLayer);
		moveanim.SetFloat("xVelocity", Mathf.Abs(rb2d.velocity.x));
		moveanim.SetFloat ("yVelocity", rb2d.velocity.y);

		if (PlayerPrefs.GetString ("Stop") == "no") {
			if (rb2d.velocity.y == 0) {
				moveanim.SetBool ("Jump", false);
			}
			movement = Input.GetAxisRaw ("Horizontal");

			if (movement > 0f) 
			{
				ice = false;
				rb2d.velocity = new Vector2 (movement * speed, rb2d.velocity.y);
				transform.localScale = new Vector2 (1f, 1f);
			} 
			else if (movement < 0f) 
			{
				ice = false;
				rb2d.velocity = new Vector2 (movement * speed, rb2d.velocity.y);
				transform.localScale = new Vector2 (-1f, 1f);
			} else {
				rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
			}


			if (Input.GetButtonDown ("Jump") && onGround) {
				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpforce);
				moveanim.SetBool ("Jump", true);
			}


			if (ice == true) 
			{
				if (transform.localScale.x == -1f) 
				{
					rb2d.velocity = new Vector2 (-0.25f * speed, rb2d.velocity.y);
				} 
				else 
				{
					rb2d.velocity = new Vector2 (0.25f * speed, rb2d.velocity.y);
				}
			}

			if (Input.GetButtonDown ("Crouch")) {
				FindObjectOfType<Headcheck> ().crouchstat = true;


			} else if (Input.GetButtonUp ("Crouch")) {
			
				FindObjectOfType<Headcheck> ().crouchstat = false;
			}

			if (Input.GetButtonDown ("Turbo")) {
				if (FindObjectOfType<HealthBar> ().stamina > 0) {	
					speed *= 2f;
					jumpforce *= 1.25f;
				} 
			}
			
		

			if (Input.GetButton ("Turbo")) {
				FindObjectOfType<HealthBar> ().LoseStamina (Time.fixedDeltaTime);
				if (FindObjectOfType<HealthBar> ().stamina <= 1) {	
					speed = 2f;
					jumpforce = 6f;
				} 
			}

			if (!Input.GetButton ("Turbo")) {
				speed = 2f;
				jumpforce = 6f;
				if (FindObjectOfType<HealthBar> ().stamina < 12)
					FindObjectOfType<HealthBar> ().GainStamina (Time.fixedDeltaTime);
			}
		
		
			if (FindObjectOfType<Headcheck> ().crouchstat == true && onGround) {
				playercollider.size = new Vector2 (0.6332169f, 0.884f);
				playercollider.offset = new Vector2 (-0.00447464f, -0.30f);
				moveanim.SetBool ("crouchstat", true);
				speed = 1f;

			} else if (FindObjectOfType<Headcheck> ().crouchstat == false) {
				playercollider.size = new Vector2 (0.6332169f, 1.360171f);
				playercollider.offset = new Vector2 (-0.00447464f, 0.01341879f);
				speed = 2f;
				if (playercollider.size.y == 1.360171f) {
					moveanim.SetBool ("crouchstat", false);
					speed = 2f;
				}	
			}	
		}
	} 

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Enemy 1" || other.tag == "Enemy 2" || other.tag == "Enemy 3" || other.tag == "Cactus") 
		{
			if (gameObject.tag == "Player")
			{	
				FindObjectOfType<HealthBar> ().LoseHealth (25);
			}
			gameObject.tag = "invul";
			delaytime = 2f;
		}
		if (other.tag == "Ice") 
		{
			ice = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Fall Detector") 
		{
			FindObjectOfType<GameOver> ().isDead = true;
		}
		if (other.tag == "GunBox") 
		{
			bullettotal += 6;
		}
		if (other.tag == "Exit") 
		{
			
			totalscore = totalscore +  Mathf.RoundToInt(FindObjectOfType<Timer> ().leveltime * 5);
			totaltime += FindObjectOfType<Timer> ().leveltime;

			PlayerPrefs.SetInt ("Totalbullet", bullettotal);
			PlayerPrefs.SetInt ("Score", totalscore);
			if (SceneManager.GetActiveScene ().name == "Stage 4") 
			{
				totaltime = 1200 - totaltime;
				if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("Highscore") || totaltime < PlayerPrefs.GetInt ("BestTime")) 
				{
					Time.timeScale = 0f;
					PlayerPrefs.SetString ("Stop", "yes");
					textfield.SetActive (true);
					if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("Highscore")) {
						PlayerPrefs.SetInt ("Highscore", PlayerPrefs.GetInt ("Score"));
						bestscorename = true;

					}
					if (totaltime < PlayerPrefs.GetInt ("BestTime")) {
						totaltime = 1200 - totaltime;
						PlayerPrefs.SetInt ("BestTime", Mathf.RoundToInt (totaltime));
						besttimename = true;
					}
				} 
			} 
			else 
			{
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			}

		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Ice") 
		{
			ice = false;
		}
	}
}
