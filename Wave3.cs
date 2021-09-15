using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Wave3 : MonoBehaviour
{
    [SerializeField]
    private GameObject _child;
    [SerializeField]
    private GameObject _player, _boss;
    [SerializeField]
    private PlayableDirector _nextTimeline;
    [SerializeField]
    private int _time;
    [SerializeField]
    private PlayableDirector _timeElapsedTimeline;

    private Vector3 _enemyPos;
    private bool _notDone = true;

    private void Start()
    {
        InstantiateChildren();
        RandomModelSelection();
        _player.GetComponent<Player>().SetWaveNumber(3);
        StartCoroutine(TimerRoutine());
        GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.GetComponent<PlayerWeaponControl>().SetDamageVal(1.5f);
    }

    private void Update()
    {
        if (transform.childCount == 0)
        {
            _nextTimeline.Play();
            _player.transform.position = new Vector3(4.03f, 0, 45.3f);
            _player.GetComponent<Player>().TopHealth();
            _boss.transform.position = new Vector3(9.34f, 0, 130.0f);
            this.gameObject.SetActive(false);
        }
    }

    private void InstantiateChildren()
    {
        _enemyPos = _player.transform.position;
        _enemyPos.z += 15;
        _enemyPos.x = Random.Range(-15.0f, -4.0f);

        GameObject _instChild1 = Instantiate(_child, _enemyPos, Quaternion.identity);
        _enemyPos.x = Random.Range(0.0f, 9.0f);
        GameObject _instChild2 = Instantiate(_child, _enemyPos, Quaternion.identity);
        _enemyPos.x = Random.Range(13.0f, 22.0f);
        GameObject _instChild3 = Instantiate(_child, _enemyPos, Quaternion.identity);
        _instChild1.transform.parent = this.gameObject.transform;
        _instChild2.transform.parent = this.gameObject.transform;
        _instChild3.transform.parent = this.gameObject.transform;
    }

    private void RandomModelSelection()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            int randNum = Random.Range(0, 4);
            child.GetChild(randNum).gameObject.SetActive(true);
        }
    }

    IEnumerator TimerRoutine()
    {
        while (_notDone)
        {
            yield return new WaitForSeconds(1.0f);
            if (_time > 0)
            {
                _time -= 1;
                UIManager.Instance.DisplayTime(_time);
            }
            else
            {
                _notDone = false;
                _timeElapsedTimeline.Play();
            }
        }
    }
}
