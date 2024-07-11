using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	// 物理演算
	public Rigidbody rb;

	// アニメーション
	public Animator animator;

	// 弾
	public GameObject bullet;
	// ゲームマネージャー
	public GameObject gameManager;
	private GameManagerScript gameManagerScript;


	// 1 秒での移動速度
	float moveSpeed = 2.0f;
	// ステージの横幅
	float stageMax = 4.0f;

	int bulletTimer = 0;

	// Start is called before the first frame update
	void Start()
	{
		gameManagerScript = gameManager.GetComponent<GameManagerScript>();

		//animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (gameManagerScript.IsGameOver())
		{
			return;
		}
		// タイムスケールが変わるとどうなるのか実験
		if (Input.GetKey(KeyCode.DownArrow))
		{
			Time.timeScale = 0.5f;
		}
		else
		{
			Time.timeScale = 1.0f;
		}

		// 横移動
		if (Input.GetKey(KeyCode.RightArrow))
		{
			if (transform.position.x < stageMax)
			{
				//rb.AddForce(moveSpeed, 0, 0);
				rb.velocity = new Vector3(moveSpeed, 0, 0);
			}
			animator.SetBool("Move", true);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (-stageMax < transform.position.x)
			{
				//rb.AddForce(-moveSpeed, 0, 0);
				rb.velocity = new Vector3(-moveSpeed, 0, 0);
			}
			animator.SetBool("Move", true);
		}
		else
		{
			rb.velocity = Vector3.zero;
			animator.SetBool("Move", false);
		}
	}

	private void FixedUpdate()
	{
		if (gameManagerScript.IsGameOver())
		{
			return;
		}
		if (Input.GetKey(KeyCode.Space))
		{
			if (bulletTimer == 0)
			{
				Vector3 position = transform.position;
				position.y += 0.8f;
				position.z += 1.0f;

				Instantiate(bullet, position, Quaternion.identity);
				bulletTimer = 1;
			}
			bulletTimer++;
			if (20 < bulletTimer)
			{
				bulletTimer = 0;
			}
		}
	}

	// 敵と接触したら終了
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			gameManagerScript.StartGameOver();
		}
	}
}
