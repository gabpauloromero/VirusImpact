using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class EnemyAI : MonoBehaviour {
	

	public List <Transform> point;
	public int id;
	int addvalue = 1;
	public float speed;
	int hp;
	Vector2 position;
	string enemytag;
	public GameObject spawn;
	Vector2 startposition;



	// Use this for initialization
	void Start () {
		hp = 4;
		speed = 1f;
		enemytag = gameObject.tag;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	private void Reset()
	{
		Init ();

	}	

	private void Init()
	{
		GetComponent<PolygonCollider2D> ().isTrigger = true;

		GameObject root = new GameObject (name + "root");

		root.transform.position = transform.position;

		transform.SetParent (root.transform);

		GameObject waypoints = new GameObject ("Waypoints");

		waypoints.transform.SetParent (root.transform);
		waypoints.transform.position = root.transform.position;

		GameObject p1 = new GameObject ("p1");
		p1.transform.SetParent (waypoints.transform);
		p1.transform.position = root.transform.position;

		GameObject p2 = new GameObject ("p2");
		p2.transform.SetParent (waypoints.transform);
		p2.transform.position =  root.transform.position;

		point = new List<Transform>();
		point.Add(p1.transform);
		point.Add(p2.transform);
	}



	private void Move()
	{
		

		if (FindObjectOfType<PlayerMovement> ().delaytime <= 0) 
		{
			gameObject.tag = enemytag;

		}
		Transform target = point [id];
		if (target.position.x>transform.position.x)
		{
			transform.localScale= new Vector3(1,1,1);
		}
		else
		{
			transform.localScale = new Vector3(-1,1,1);
		}	

		if (PlayerPrefs.GetString ("Stop") == "no") {
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.fixedDeltaTime);
		}

		if (Vector2.Distance (transform.position, target.position) < 1f) 
		{
			if (id == point.Count - 1) 
			{
				addvalue = -1;
			}
			if (id == 0) 
			{
				addvalue = 1;
			}
			id += addvalue;
		}
		position = transform.position;
	}	

	private void OnTriggerEnter2D(Collider2D collison)
	{
		if (collison.tag == "Bullet" || collison.tag == "Vitamin") 
		{
			hp -= 1;
			if (hp == 0) 
			{
				startposition = this.transform.position;
				Destroy (transform.parent.gameObject);
				FindObjectOfType<PlayerMovement> ().totalscore += 25;
				if (SceneManager.GetActiveScene ().name == "Stage 4") 
				{
					Instantiate (spawn, startposition, transform.rotation);
				}
			}
	}
}
}
