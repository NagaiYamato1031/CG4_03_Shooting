using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
	// 敵実体
	public GameObject enemy;

	// ゲームオーバーテキスト
	public GameObject gameoverText;
	// スコアテキスト
	public TextMeshProUGUI scoreText;

	// ヒットパーティクル
	public GameObject bombParticle;
	// ヒットSE
	public AudioSource hitAudioSource;
	
	// ゲームオーバーフラグ
	private bool gameOverFlag = false;
	// スコア
	private int score = 0;

	// 経過時間
	private int gameTimer = 0;

	// Start is called before the first frame update
	void Start()
	{
		gameTimer = 0;
		Screen.SetResolution(1980, 1080, false);
	}

	// Update is called once per frame
	void Update()
	{
		// ゲームオーバー
		if(gameOverFlag && Input.GetKeyDown(KeyCode.Return))
		{
			SceneManager.LoadScene("TitleScene");
		}
		// スコア表示
		scoreText.text = "Score:" + score;

	}

	private void FixedUpdate()
	{
		// ゲームオーバーなので敵を発生させない
		if (gameOverFlag)
		{
			return;
		}

		// 難易度上昇
		gameTimer++;
		int max = 50 - gameTimer / 100;
		int r = Random.Range(0, max);
		if (r == 0)
		{
			float x = Random.Range(-3.0f, 3.0f);
			Instantiate(enemy, new Vector3(x, 0, 10), Quaternion.identity);
		}
	}

	// ゲームオーバー関数
	public void StartGameOver()
	{
		gameOverFlag = true;
		gameoverText.SetActive(true);
	}

	public bool IsGameOver()
	{
		return gameOverFlag;
	}

	// 弾と接触
	public void Hit(Vector3 position)
	{
		Instantiate(bombParticle,position, Quaternion.identity);
		hitAudioSource.Play();
		score++;
	}

}
