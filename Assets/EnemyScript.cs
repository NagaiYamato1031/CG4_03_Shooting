using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public float moveSpeed;

	private GameObject gameManager;
	private GameManagerScript gameManagerScript;

	// Start is called before the first frame update
	void Start()
	{
		// ゲームマネージャーのオブジェクトを探す
		gameManager = GameObject.Find("GameManager");
		// スクリプトを取得
		gameManagerScript = gameManager.GetComponent<GameManagerScript>();
		// 自動で消す
		Destroy(gameObject, 5);
		int r = Random.Range(0,2) == 1 ? 30 : -30;
		transform.rotation = Quaternion.Euler(0, 180 + r, 0);	
	}

	// Update is called once per frame
	void Update()
	{
		// ゲームオーバーなら
		if (gameManagerScript.IsGameOver())
		{
			return;
		}
		// 左右で反転
		if(transform.position.x < -4)
		{
			transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
		}
		else if(4 < transform.position.x)
		{
			transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
		}

		Vector3 velocity = new Vector3 (0,0,moveSpeed * Time.deltaTime);
		transform.position += transform.rotation * velocity;
	}
}
