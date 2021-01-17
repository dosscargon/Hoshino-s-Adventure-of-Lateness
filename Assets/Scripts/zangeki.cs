using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zangeki : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {

            //効果音
            AudioSource sound = GetComponents<AudioSource>()[0];
            sound.PlayOneShot(sound.clip);
        }
        
    }
}
