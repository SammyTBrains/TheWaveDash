using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 13.0f;
    [SerializeField]
    private float _leftRightSpeed = 5.0f;
    [SerializeField]
    private float _health;
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private GameObject _explosion;
    [SerializeField]
    private AudioClip _explosionSound;
    [SerializeField]
    private Camera _mainCamera;
    [SerializeField]
    private PlayableDirector _gameOverTimeline;

    private bool _rightPressed = false;
    private bool _leftPressed = false;
    private bool _shielded = false;

    private int _waveNumber;

    // Start is called before the first frame update
    void Start()
    {
        _maxHealth = 70.0f;
        _health = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        if (_rightPressed)
        {
            transform.Translate(Vector3.right * Time.deltaTime * _leftRightSpeed);
        }
        else if (_leftPressed)
        {
            transform.Translate(Vector3.left * Time.deltaTime * _leftRightSpeed);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -17, 31), transform.position.y, transform.position.z);
    }

    public float CalculateHealth()
    {
        return (_health / _maxHealth) * 1;
    }

    public void SetWaveNumber(int waveNo)
    {
        _waveNumber = waveNo;
    }
    public int GetWaveNumber()
    {
        return _waveNumber;
    }

    public void TopHealth()
    {
        if(_health <= 50)
        {
            _health += 20;
            UIManager.Instance.DisplayHealth(CalculateHealth());
        }
    }

    public void SetShielded(bool shielded)
    {
        _shielded = shielded;
    }
    public void DamageHandler(float damage)
    {
        Vector3 pos = transform.position;
        pos.y += 3;
        pos.z -= 2;

        if (_shielded)
        {
            return;
        }
        else
        {
            if (_health > 0)
            {
                _health -= damage;
                UIManager.Instance.DisplayHealth(CalculateHealth());
            }
            else
            {
                GameObject explosion = Instantiate(_explosion, pos, Quaternion.identity);
                AudioSource.PlayClipAtPoint(_explosionSound, _mainCamera.transform.position);
                _mainCamera.transform.parent = null;
                Destroy(explosion, 3.0f);
                _gameOverTimeline.Play();
                Destroy(this.gameObject);
            }
        }
        
    }

    public void LeftButtonDown()
    {
        _leftPressed = true;
    }

    public void LeftButtonUp()
    {
        _leftPressed = false;
    }

    public void RightButtonDown()
    {
        _rightPressed = true;
    }

    public void RightButtonUp()
    {
        _rightPressed = false;
    }

}
