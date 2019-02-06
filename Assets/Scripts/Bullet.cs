using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioSource sfxDie;
    public Rigidbody2D rigidbody2D;
    public float speed = 4;
    // Use this for initialization
    void Start()
    {
        rigidbody2D.AddForce(transform.up * speed);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        sfxDie.Play();  
        collision.gameObject.SendMessage("Damage");
        rigidbody2D.bodyType = RigidbodyType2D.Static;
        GetComponent<Renderer>().enabled = false;
        GetComponent<Boundary>().enabled = false;
        Destroy(gameObject, 2);
	}
}
