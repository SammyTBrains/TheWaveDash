using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UI Manager is null!");
            }

            return _instance;
        }
    }

    [SerializeField]
    private Slider _healthBar;
    [SerializeField]
    private Text _timer;
    [SerializeField]
    private GameObject _pauseMenu, _pauseButton;

    private Color _timerColor;
    private int _fontSize;
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _healthBar.value = 1;
        _timerColor = _timer.color;
        _fontSize = _timer.fontSize;
    }

    public void DisplayTime(int time)
    { 
        if(time <= 5)
        {
            _timer.color = Color.red;
            _timer.fontSize = 30;
        }
        else
        {
            _timer.color = _timerColor;
            _timer.fontSize = _fontSize;
        }
        _timer.text = time.ToString();
    }
    public void DisplayHealth(float health)
    {
        _healthBar.value = health;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
        _pauseButton.SetActive(false);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
        _pauseButton.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        InterstitialAd.Instance.LoadAd();
        InterstitialAd.Instance.ShowAd();
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        InterstitialAd.Instance.LoadAd();
        InterstitialAd.Instance.ShowAd();
        SceneManager.LoadScene(0);
    }
}
