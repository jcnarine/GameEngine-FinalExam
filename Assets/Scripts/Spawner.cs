using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using TMPro;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
	{

	public struct objectInfo
		{
		public float _minX, _maxX;
		public int _minSize, _maxSize;
		public float _minSpeed, _maxSpeed;
		public float _minRotation, _maxRotation;
		}

	public objectInfo asteroidInfo;

	//Prefabs//

	public Asteroid _AsteroidPrefab;
	public Enemy _EnemyPrefab;

	//Text//

	public TextMeshProUGUI _TimerText;
	public TextMeshProUGUI _TotalPoints;
	public TextMeshProUGUI _Achievement;

	public Material material;

	//Spawn and Wave Variables 

	public float spawnTimer;
	public int _Timer;
	public static int _enemyTotal;
	public static int _totalEnemiesDestroyed;
	private int _enemyCount;

	public static int totalPoints;

	public bool _displayFive, _displayTen;
	//
	Vector3 _SpawnLocation;
	public Canvas _Menu;

	[DllImport("ColorSwitch")]

	private static extern float incrementFloatValue(float value, float increment, float max);

	public float increment;

	private float H, S, V;

	// Start is called before the first frame update
	void Start()
		{

		_Achievement.gameObject.SetActive(false);
		_SpawnLocation = transform.position;

		_enemyTotal = 100;
		_Timer = 90;

		_displayFive = false;
		_displayTen = false;

		//This helps organize all the values between the two objects and allows for easy customization
		asteroidInfo._minX = -848;
		asteroidInfo._maxX = 812;
		asteroidInfo._minSize = 15;
		asteroidInfo._maxSize = 50;
		asteroidInfo._minSpeed = 0.5f;
		asteroidInfo._maxSpeed = 2;
		asteroidInfo._minRotation = 1;
		asteroidInfo._maxRotation = 3;

		_Menu.enabled = true;
		}
	private void Update()
		{

		checkGameStatus();

		_TimerText.text = "Timer:" + _Timer;
		_TotalPoints.text = "Score:" + totalPoints;
		_Achievement.color = new Color32(255, 128, 0, 255);

		}
	public void StartGame()
		{
		_Menu.enabled = false;
		_Menu.gameObject.SetActive(false);
		Invoke("SpawnEnemies", spawnTimer);
		Invoke("decreaseTimer", 1);
		}

	public void StartTutorial()
		{
		SceneManager.LoadScene("Tutorial");
		}


	public void turnoffAchievement() { _Achievement.gameObject.SetActive(false); }

	public void changeColor() {

		Color.RGBToHSV(material.color, out H, out S, out V);
		material.color = Color.HSVToRGB(incrementFloatValue(H, 0.01f, 1.0f), S, V);

		}
	void checkGameStatus()
		{

		if (_totalEnemiesDestroyed == 5 && _displayFive == false) {
			_Achievement.text = "ACHIEVEMENT: 5 ENEMIES DESTROYED";
			_Achievement.gameObject.SetActive(true);
			_displayFive = true;
			Invoke("changeColor", 0.1f);
			Invoke("turnoffAchievement", 5.0f);
			}

		if (_totalEnemiesDestroyed == 10 && _displayTen == false) {
			_Achievement.text = "ACHIEVEMENT: 10 ENEMIES DESTROYED";
			_Achievement.gameObject.SetActive(true);
			_displayFive = true;
			Invoke("changeColor", 0.1f);
			Invoke("turnoffAchievement", 5.0f);
			}

		if (_enemyTotal == _totalEnemiesDestroyed || _Timer == 0)
			{
				_enemyTotal = 1;
				_enemyCount = 0;
				_totalEnemiesDestroyed = 0;
				SceneManager.LoadScene("YouWon");
			}
		}

	public void decreaseTimer() { _Timer--; Invoke("decreaseTimer", 1); }
	
	void SpawnEnemies()
		{

		if (_enemyCount < _enemyTotal)
			{
			if (Random.Range(0, 2) > 0)
				{

				_SpawnLocation.x = Random.Range(asteroidInfo._minX, asteroidInfo._maxX);

				Asteroid asteroid = Instantiate(_AsteroidPrefab, _SpawnLocation, Quaternion.identity);

				asteroid.SetRotation(Random.Range(asteroidInfo._minRotation, asteroidInfo._maxRotation));
				asteroid.SetSpeed(Random.Range(asteroidInfo._minSpeed, asteroidInfo._maxSpeed));
				asteroid.SetScale(Random.Range(asteroidInfo._minSize, asteroidInfo._maxSize));
				asteroid.SetLives(1);
				asteroid.SetDirection(new Vector3(0, -1, 0));

				Invoke("SpawnEnemies", spawnTimer);
				_enemyCount++;
				}
			else
				{
				_SpawnLocation.x = Random.Range(asteroidInfo._minX, asteroidInfo._maxX);
				Instantiate(_EnemyPrefab, _SpawnLocation, Quaternion.Euler(0f, -90f, 90f));
				_enemyCount++;
				Invoke("SpawnEnemies", spawnTimer);
				}

			}
		}
	}


/*
 		
 */