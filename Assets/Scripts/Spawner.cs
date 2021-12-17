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

	public TextMeshProUGUI WaveText;
	public TextMeshProUGUI _enemyCountText;
	public TextMeshProUGUI _waveCountText;


	//Spawn and Wave Variables 

	public float spawnTimer;
	public int _Wave = 1;
	public static int _enemyTotal = 1, _waveTotal = 1;
	public static int _totalEnemiesDestroyed;
	private int enemyCount;

	//
	Vector3 _SpawnLocation;
	public Canvas _Menu;

	// Start is called before the first frame update
	void Start()
		{

		_SpawnLocation = transform.position;

		_enemyTotal = 1;
		_waveTotal = 1;
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

		while (CommandInvoker.commandHistory.Count > CommandInvoker.counter)
			{
			CommandInvoker.commandHistory.RemoveAt(CommandInvoker.counter);
			}
		CommandInvoker.counter = 0;

		}
	private void Update()
		{

		if (_Menu.enabled == true)
			{
			_enemyCountText.text = "Enemy Count: " + _enemyTotal;
			_waveCountText.text = "Total Waves: " + _waveTotal;
			}

		nextWave();

		}
	public void StartGame()
		{
		_Menu.enabled = false;
		_Menu.gameObject.SetActive(false);
		Invoke("SpawnEnemies", spawnTimer);
		}

	public void StartTutorial()
		{
		SceneManager.LoadScene("Tutorial");
		}
	void nextWave()
		{

		Debug.Log(_Wave + " " + _waveTotal + "\n");

		if (_enemyTotal == _totalEnemiesDestroyed)
			{
			if (_Wave == _waveTotal)
				{
				_enemyTotal = 1;
				_waveTotal = 1;
				enemyCount = 0;
				_totalEnemiesDestroyed = 0;
				SceneManager.LoadScene("YouWon");
				}
			if (_Wave < _waveTotal)
				{
				_Wave++;
				_totalEnemiesDestroyed = 0;
				enemyCount = 0;
				WaveText.text = "Wave " + _Wave;
				SpawnEnemies();
				}
			}
		}

	public void addValue(int i)
		{
		switch (i)
			{

			case (0):
				ICommand foePlus = new EnemyUp();
				CommandInvoker.AddCommand(foePlus);
				break;
			case (1):
				ICommand wavePlus = new WavesUp();
				CommandInvoker.AddCommand(wavePlus);
				break;
			}
		}
	public void undoAction() { CommandInvoker.UndoCommand(); }
	void SpawnEnemies()
		{

		if (enemyCount < _enemyTotal)
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
				enemyCount++;
				}
			else
				{
				_SpawnLocation.x = Random.Range(asteroidInfo._minX, asteroidInfo._maxX);
				Instantiate(_EnemyPrefab, _SpawnLocation, Quaternion.Euler(0f, -90f, 90f));
				enemyCount++;
				Invoke("SpawnEnemies", spawnTimer);
				}

			}
		}
	}


/*
 		
 */