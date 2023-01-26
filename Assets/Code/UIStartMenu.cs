using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class UIStartMenu : MonoBehaviour
{
    [SerializeField] private float _easySpeed;
    [SerializeField] private float _normalSpeed;
    [SerializeField] private float _hardSpeed;
    private PlayerStartSpeed _playerStartSpeed;
    private Timer _timer;
    [Inject]
    public void Construct(PlayerStartSpeed playerStartSpeed, Timer timer)
    {
        _playerStartSpeed = playerStartSpeed;
        _timer = timer;
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("Restart") && PlayerPrefs.GetInt("Restart") == 1)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    public void SetSpeedToEasy()
    {
        _playerStartSpeed.SwitchSpeed(_easySpeed);
    }
    public void SetSpeedToNormal()
    {
        _playerStartSpeed.SwitchSpeed(_normalSpeed);
    }
    public void SetSpeedToHard()
    {
        _playerStartSpeed.SwitchSpeed(_hardSpeed);
    }
    public void Play()
    {
        Time.timeScale = 1;
        _timer.TimerStart();
        gameObject.SetActive(false);
    }
}
