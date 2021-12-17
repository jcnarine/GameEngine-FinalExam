using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    private bool _dirty = true;
    private int Continue = 0;

    public TextMeshProUGUI tutorialText; 
    public TextMeshProUGUI WaveText;
    public TextMeshProUGUI Lives;
    public TextMeshProUGUI _enemyCountText;
    public TextMeshProUGUI _waveCountText;

    public GameObject plus1, plus2, startgame, undo;
    // Start is called before the first frame update
    void Start()
    {
        WaveText.gameObject.SetActive(false);
        Lives.gameObject.SetActive(false);
        _enemyCountText.gameObject.SetActive(false);
        _waveCountText.gameObject.SetActive(false);
        plus1.gameObject.SetActive(false);
        plus2.gameObject.SetActive(false);
        startgame.gameObject.SetActive(false);
        undo.gameObject.SetActive(false);

        }

    public void pressedContinue() 
        { _dirty = true; }

    public void skipTutorial() 
        { SceneManager.LoadScene("Game"); }

    // Update is called once per frame
    void Update()
    {
        if (_dirty) 
            {
            _dirty = false;
            Script();
            }
    }

    public void Script() 
        {

        switch (Continue)
            {
            case (0):
                tutorialText.text = "Welcome to Space Shooter, a game where you play a lone spacecraft flying in the cosmos.";
                break;
            case (1):
                tutorialText.text = "The contols for this game are pretty simple, just use the arrow keys to move and the spacebar to fire your bullets";
                break;
            case (2):
                WaveText.gameObject.SetActive(true);
                Lives.gameObject.SetActive(true);
                tutorialText.text = "The text above displays the current amount of lives you have and the current wave you are on.";
                break;
            case (3):
                tutorialText.text = "This tells you how close you are to dying or completing the game";
                break;
            case (4):
                WaveText.gameObject.SetActive(false);
                Lives.gameObject.SetActive(false);
                tutorialText.text = "In addition, this game has a level editor, that lets you create custom levels";
                break;
            case (5):
                _enemyCountText.gameObject.SetActive(true);
                _waveCountText.gameObject.SetActive(true);
                plus1.gameObject.SetActive(true);
                plus2.gameObject.SetActive(true);
                tutorialText.text = "Press the add button to increase the number of enemies per wave or the total amount of waves";
                break;
            case (6):
                _enemyCountText.gameObject.SetActive(false);
                _waveCountText.gameObject.SetActive(false);
                plus1.gameObject.SetActive(false);
                plus2.gameObject.SetActive(false);
                startgame.gameObject.SetActive(true);
                undo.gameObject.SetActive(true);
                tutorialText.text = "If you ever want to undo your choice, hit the undo button";
                break; 
            case (7):
                tutorialText.text = "By pressing the start button you can begin the game.";
                break;
            case (8):
                startgame.gameObject.SetActive(false);
                undo.gameObject.SetActive(false);
                tutorialText.text = "Now, press the continue or skip tutorial button to go back to the main menu";
                break;
            case (9):
                SceneManager.LoadScene("Game");
                break;
            }

        Continue++;
        }


}
