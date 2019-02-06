using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public GameObject bulletPrefab;
    public float thruster = 10;
    public Rigidbody2D rigidbody2D;
    public float turnspeed = 4;
    public AudioSource sfxDie;
    public AudioSource sfxThrust;

	void Start()
	{
        sfxThrust.Pause();
	}

	void Update () {
        if (Input.GetKey(KeyCode.UpArrow)) {
            rigidbody2D.AddForce(transform.up * thruster);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            sfxThrust.UnPause();  
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            sfxThrust.Pause();  
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -turnspeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, turnspeed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
        sfxDie.Play();
        Destroy(gameObject, 1);
	}
}
