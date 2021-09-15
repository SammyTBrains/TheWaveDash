using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    private float _speed = 13f, _damageVal = 5.0f;
    [SerializeField]
    private GameObject _explosion;
    [SerializeField]
    private AudioClip _explosionSound;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        Destroy(this.gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(_explosionSound, transform.position);
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.DamageHandler(_damageVal);
            }
        }
        Destroy(explosion, 3.0f);
        Destroy(this.gameObject);
    }
}
