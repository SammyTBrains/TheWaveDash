using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float _health;
    [SerializeField]
    protected GameObject _explosion;
    [SerializeField]
    protected AudioClip _explosionSound;

    public void DamageHandler(float damage)
    {
        Vector3 pos = transform.position;
        pos.y += 3;

        if (_health > 0)
        {
            _health -= damage;
        }
        else
        {
            GameObject explosion = Instantiate(_explosion, pos, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_explosionSound, Camera.main.transform.position);
            Destroy(explosion, 3.0f);
            Destroy(this.gameObject);
        }
    }
}
