using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	public Text StatusText;
	public Text gameOverText;
	public Text restartText;
	public GameObject theBall;
	private bool BallHere;
	private bool end;
	private int playerScore;
	private int apponentScore;


	void Start()
	{
		end = false;
		BallHere = true;
		playerScore = 0;
		apponentScore = 0;
		StatusText.text = "";
		gameOverText.text = "";
		restartText.text = "";
		StatusText.text = "A " + apponentScore.ToString()+ " : " + playerScore.ToString() + " B";
		//WaitForSeconds(startWait);
		SpawnNewBall ();
	}

	void Update()//caller of Win() & Restart() & Spawn New Ball
	{
		//Score Update
		StatusText.text = "A "+ apponentScore.ToString() + " : " + playerScore.ToString() + " B";
		//Win Check
		if (playerScore == 3) {Win("Player");}
		else if (apponentScore == 3) {Win ("Apponent");}
		//New Ball
		else if (BallHere == false) {SpawnNewBall();} 
		//End Check
		if (end) {
			restartText.text = "Press 'R' to Restart";
			Restart ();
		}
	}

	void Win(string winner)
	{
		if (winner == "Player") {
			gameOverText.text = "PlayerB Wins!";
		} else {
			gameOverText.text = "PlayerA Wins!";
		}
		end = true;
	}

	void Restart ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	void SpawnNewBall()
	{
		//WaitForSeconds (spawnWait);
		Quaternion ballRotation = Quaternion.identity;
		Vector3 ballPosition = new Vector3 (-11.5f, 0.0f, 0.0f); 
		Instantiate (theBall, ballPosition ,ballRotation);
		BallHere = true; //Remember to set the flag!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1

	}

	public void UpdateScore(string target)
	{
		if (target == "Player") {playerScore++;} 
		else if (target == "Apponent") {apponentScore++;}
		BallHere = false;
	}
}
