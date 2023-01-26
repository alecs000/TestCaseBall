using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class UILoseMenu : MonoBehaviour
{
    private const string NUMBEROFATTEMPTS = "NUMBEROFATTEMPTS";
    private const string RESTART = "Restart";
    [SerializeField] private TMP_Text _time;
    [SerializeField] private TMP_Text _numberOfAttempts;
    private Timer _timer;
    private PlayerStartSpeed _playerStartSpeed;
    [Inject]
    public void Construct(PlayerStartSpeed playerStartSpeed, Timer timer)
    {
        _playerStartSpeed = playerStartSpeed;
        _timer = timer;
    }
    private void OnEnable()
    {
        Time.timeScale = 0;
        _time.text = _timer.Passed.ToString();
        int numberOfAttempts = 0;
        // ≈сли будет важные данные можно сериализовать в Json.
        if (PlayerPrefs.HasKey(NUMBEROFATTEMPTS))
            numberOfAttempts = PlayerPrefs.GetInt(NUMBEROFATTEMPTS);
        numberOfAttempts++;
        PlayerPrefs.SetInt(NUMBEROFATTEMPTS, numberOfAttempts);
        _numberOfAttempts.text = numberOfAttempts.ToString();
    }
    public void Restart()
    {
        // ≈сли писать архитектуру это не понадобитьс€.
        PlayerPrefs.SetInt(RESTART, 1);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SwitchDifficult()
    {
        PlayerPrefs.SetInt(RESTART, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
