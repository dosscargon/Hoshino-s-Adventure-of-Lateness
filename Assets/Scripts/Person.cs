using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Person : MonoBehaviour {
    Rigidbody2D rig;
    BoxCollider2D col;
    public GameObject zangeki;
    public float speed;
    public float jump;
    public float limit;
    public float atackLimit;
    public float lay;
    public LayerMask ground;
    public LayerMask enemy;
    int zangekiTimer = 0;
    public int zangekianimation;
    public Vector2 knock;
    public bool pause;

    public bool grounded {
        get {
            //return Physics2D.BoxCast(new Vector2(transform.position.x- transform.lossyScale.x*0.5f, transform.position.y), new Vector2(transform.position.x+transform.lossyScale.x*0.5f, transform.position .y-1.2f), 0, Vector2.zero);

            return Physics2D.Linecast(new Vector2(transform.position.x - transform.lossyScale.x * 0.45f, transform.position.y - lay), new Vector2(transform.position.x + transform.lossyScale.x * 0.45f, transform.position.y - lay), ground);


        }
    }

    public bool lefted { get; set; }

    // Use this for initialization
    void Start() {
        rig = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        GetComponent<Animator>().speed = 0;
        Time.timeScale = 1;
        pause = false;

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Pause")) {
            if (Timer.mode == Timer.Mode.main) {
                Timer.mode = Timer.Mode.pause;
                pause = true;
                Debug.Log("p");
            }
        }

        if (Timer.mode == Timer.Mode.main) {
            GetComponent<Animator>().speed = (Mathf.Abs(rig.velocity.x) / limit) * 2;
        } else {
            GetComponent<Animator>().speed = 0;
        }
        if (Input.GetButtonDown("Fire1")) {
            if (Mathf.Abs(rig.velocity.x) > atackLimit && grounded) {
                rig.velocity = new Vector2(atackLimit * Mathf.Sign(rig.velocity.x), rig.velocity.y);
            }
            zangeki.SetActive(true);
            zangekiTimer = 1;
            //効果音
            AudioSource sound = GetComponents<AudioSource>()[0];
            sound.PlayOneShot(sound.clip);
        }

        if (zangeki.activeSelf == false) {
            zangeki.GetComponent<SpriteRenderer>().flipX = lefted;
            if (!lefted) {
                zangeki.transform.position = transform.position + new Vector3(2.06f, 0f, 0f);
            } else {
                zangeki.transform.position = transform.position + new Vector3(-2.06f, 0f, 0f);
            }
        }

        if (zangekiTimer >= zangekianimation) {
            zangekiTimer = 0;
            zangeki.SetActive(false);
        }

        if (Input.GetButtonDown("Jump") && (grounded || Title.debug)) {
            rig.velocity -= new Vector2(0, rig.velocity.y);
            rig.AddForce(new Vector2(0f, jump));
            //効果音
            AudioSource sound = GetComponents<AudioSource>()[1];
            sound.PlayOneShot(sound.clip);
        }


        //GetComponent<SpriteRenderer>().flipY = !grounded;
        GetComponent<SpriteRenderer>().flipX = lefted;
        /*if (lefted)
		{
			transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
		}
		else
		{
			transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

		}*/

        if (pause) {
            Debug.Log("p");
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }

        if (transform.position.y <= -10 && Timer.mode == Timer.Mode.main) {
            Timer.mode = Timer.Mode.gameover;
            //効果音
            AudioSource sound = GetComponents<AudioSource>()[3];
            sound.PlayOneShot(sound.clip);
        }
    }

    void FixedUpdate() {
        if (zangekiTimer != 0) {
            zangekiTimer++;
        }

        if (Input.GetAxis("Horizontal") > 0.3)//right
        {
            if (!grounded && lefted) {
                rig.velocity -= new Vector2(rig.velocity.x / 3, 0);
            }
            if (Mathf.Abs(rig.velocity.x) < limit) {
                rig.AddForce(new Vector2(speed, 0f));
            }
            lefted = false;
        }
        if (Input.GetAxis("Horizontal") < -0.3)//left
        {
            if (!grounded && !lefted) {
                rig.velocity -= new Vector2(rig.velocity.x / 3, 0);
            }
            if (Mathf.Abs(rig.velocity.x) < limit) {
                rig.AddForce(new Vector2(-speed, 0f));
            }
            lefted = true;
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {

        if (coll.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
            rig.velocity = Vector3.zero;
            if (transform.position.x <= coll.transform.position.x) {
                rig.AddForce(new Vector2(-knock.x, knock.y));
                //Debug.Log(coll.gameObject.layer);
            } else {
                rig.AddForce(knock);
            }
            Timer.time += 180;

            //効果音
            AudioSource sound = GetComponents<AudioSource>()[2];
            sound.PlayOneShot(sound.clip);
        } else if (coll.gameObject.layer == LayerMask.NameToLayer("Goal")) {
            Lanking.getInstance().updateCSN();
            Timer.mode = Timer.Mode.goal;
            GetComponent<Animator>().speed = 0;
        }
    }
}
