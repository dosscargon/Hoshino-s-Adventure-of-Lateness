using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float speed;
	public float limit;
	public Vector2 knock;
	public GameObject person;

	Rigidbody2D rig;

	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (person != null)
		{
			if (Mathf.Abs(rig.velocity.x) < limit && Mathf.Abs(person.transform.position.x - transform.position.x) <= 25f && Mathf.Abs(rig.velocity.y) < limit && Mathf.Abs(person.transform.position.y - transform.position.y) <= 15f)
			{
				rig.AddForce(new Vector2(-speed, 0f));
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log(LayerMask.LayerToName( coll.gameObject.layer));
		if (coll.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			rig.velocity = Vector3.zero;
			if (transform.position.x <= coll.transform.position.x)
			{
				rig.AddForce(new Vector2(-knock.x, knock.y));
				
			}
			else
			{
				rig.AddForce(knock);
			}
		}
		if(coll.gameObject.layer==9){
			GetComponent<CircleCollider2D>().enabled = false;
			Debug.Log("w");
			if (transform.position.x <= coll.transform.position.x)
			{
				rig.AddForce(new Vector2(-knock.x, knock.y));
				//Debug.Log(coll.gameObject.layer);
			}
			else
			{
				rig.AddForce(knock);
			}
			Timer.time -= 180;
		}


	}
}
