using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaucherEnemies : MonoBehaviour
{
    [SerializeField]
    private GameObject _missile;
    [SerializeField]
    private float _cooldownTime = 3.0f;

    private bool _launched = false;

    // Update is called once per frame
    void Update()
    {
        if (_launched == false)
        {
            _launched = true;
            Firing();
        }
    }

    private void Firing()
    {
        RaycastHit hit;

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit))
        {
            GameObject missile = Instantiate(_missile, this.transform.position, Quaternion.identity);
            missile.transform.parent = this.transform;
            missile.transform.rotation = this.transform.rotation;
            StartCoroutine(LaunchRoutine());
        }
    }

    IEnumerator LaunchRoutine()
    {
        yield return new WaitForSeconds(_cooldownTime);
        _launched = false;
    }
}
