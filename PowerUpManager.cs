using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private static PowerUpManager _instance;
    public static PowerUpManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("Power Up Manager is null");
            }

            return _instance;
        }
    }

    [SerializeField]
    private GameObject _shield, _damagex2;
    [SerializeField]
    private float _zPositionOffset = 20.0f, _yPositionOffset = 5.0f; 

    private Player _player;

    private bool isCooldown = true;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (isCooldown && this.gameObject.activeInHierarchy == true && _player.gameObject.activeSelf == true)
        {
            isCooldown = false;
            Vector3 pos = _player.transform.position;
            pos.z += _zPositionOffset;
            pos.y += _yPositionOffset;
            pos.x = Random.Range(-15.0f, 22.0f);
            int randNo = Random.Range(1, 3);
            GameObject asset = null;
            switch (randNo)
            {
                case 1:
                    asset = _shield;
                    break;
                case 2:
                    asset = _damagex2;
                    break;
            }
            GameObject powerUp = Instantiate(asset, pos, Quaternion.identity);
          
            StartCoroutine(CoolDownRoutine());
            Destroy(powerUp, 11.0f);     
        }
    }

    IEnumerator CoolDownRoutine()
    {
        yield return new WaitForSeconds(Random.Range(9.0f, 10.0f));
        isCooldown = true;
    }
}
