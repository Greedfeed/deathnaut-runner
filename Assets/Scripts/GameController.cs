using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	Transform player;

	public GUIText scoreText;
	public GUIText highScoreText;	
	public GUIText restartText;
	public GUIText gameOverText;
	
	private bool gameOver;
	private bool restart;
	private int score = 0;
	private int highScore;
	

	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";

		highScore = PlayerPrefs.GetInt ("Score");
		highScoreText.text = "High Score: " + highScore;

		UpdateScore ();

		StartCoroutine (SpawnWaves ());

		GameObject playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.transform;
	}

	void Update ()
	{
		if (restart)
		{
			if (Input.GetButton("Fire1"))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 pos = transform.position;
				pos.x = player.position.x;

				Vector3 spawnPosition = new Vector3 (pos.x + spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver)
			{
				restartText.text = "Tap to Replay";
				restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;

		if (score > highScore)
		{
			highScoreText.text = "High Score: " + score;
			PlayerPrefs.SetInt("Score", score);
		}
			
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}

}