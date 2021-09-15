using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerMenu : MonoBehaviour
{
    private GameObject[] _bgMusicObjs;
    private int _arrLength;

    private void Start()
    {
        _bgMusicObjs = GameObject.FindGameObjectsWithTag("BGMusic");
        _arrLength = _bgMusicObjs.Length;
    }

    private void Update()
    {
        if (_arrLength > 1)
        {
            Destroy(_bgMusicObjs[1]);
        }
    }

    public void StartGame()
    {
        Destroy(_bgMusicObjs[0]);
        SceneManager.LoadScene(1);
    }

    public void HowToPlay()
    {
        DontDestroyOnLoad(_bgMusicObjs[0]);
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
