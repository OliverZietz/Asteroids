using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    public float startSpeed = 5;
    public GameObject childrenPrefab;
    public string type;
    public bool useStartSpeed;
    public float outwardForce = 1;
    public int score = 5;

	private void Start()
    {
        if (useStartSpeed){
            GetComponent<Rigidbody2D>().velocity = Random.onUnitSphere * startSpeed;
        }
	}

	public void Damage(){
        Vector2 ourVelocity = GetComponent<Rigidbody2D>().velocity;
        Vector2 outwardVelocity = Vector2.zero;

        if (type == "large" || type == "medium") {
            GameObject cluster = Instantiate(childrenPrefab, transform.position, transform.rotation);
            cluster.transform.SetParent(transform.parent);
            foreach (Transform child in cluster.transform) {
                outwardVelocity = child.position - cluster.transform.position;
                child.GetComponent<Rigidbody2D>().velocity = ourVelocity + outwardVelocity.normalized * outwardForce; 
            } 
        }
        UIManager manager = FindObjectOfType<UIManager>();
        manager.AddScore(score);
        Destroy(gameObject);
    }
}
