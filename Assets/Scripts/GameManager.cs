using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBeat;
    public static GameManager instance;
    public int currentScore;
    public int scorePerHit = 100;

    public TextMeshProUGUI scoreText;

    public float totalNotes;
    public float hitNotes;
    public float missedHits;

    public GameObject startScreen;
    public TextMeshProUGUI startText, instructionsText;

    public GameObject resultsScreen;
    public TextMeshProUGUI percentHitText, hitsText, missesText, finalScoreText;
    // Start is called before the first frame update

    public void NoteHit()
    {
        Debug.Log("Hit on time");

        currentScore += scorePerHit;
        scoreText.text = "Score: " + currentScore;

        hitNotes++;
    }

    public void NoteMissed()
    {
        Debug.Log("Not Hit");

        missedHits++;
    }
    void Start()
    {
        instance = this;

        startScreen.SetActive(true);
        resultsScreen.SetActive(false);

        scoreText.text = "Score: 0";

        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Game Starts");
                
                startScreen.SetActive(false);

                startPlaying = true;
                theBeat.hasStarted = true;

                theMusic.Play();
            }

        }
        else
        {
            if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                Debug.Log("Show Results");

                hitsText.text = "" + hitNotes;
                missesText.text = "" + missedHits;

                float totalHit = hitNotes;
                float percentHit = (totalHit / totalNotes) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";

                finalScoreText.text = currentScore.ToString();

                resultsScreen.SetActive(true);
            }
        }
    }

  
}
