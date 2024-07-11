using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

	public Rigidbody rb;

	public float moveSpeed = 100.0f;

	// Start is called before the first frame update
	void Start()
	{
		rb.velocity = new Vector3(0, 0, moveSpeed);
		Destroy(gameObject, 5);
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			// オブジェクトとスクリプト取得
			GameObject gm = GameObject.Find("GameManager");
			GameManagerScript gms = gm.GetComponent<GameManagerScript>();
			gms.Hit(transform.position);

			Destroy(collision.gameObject);
			Destroy(this.gameObject);
		}
	}
}
