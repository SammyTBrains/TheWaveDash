using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageX2 : MonoBehaviour
{
    private GameObject _damageX2Indicator;
    private GameObject _canvas;
    private PlayerWeaponControl _playerWeaponControl;

    private void Start()
    {
        _canvas = GameObject.FindGameObjectWithTag("Canvas");
        _damageX2Indicator = _canvas.transform.GetChild(6).gameObject;
        _playerWeaponControl = _canvas.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.GetComponent<PlayerWeaponControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            float damageVal;
            damageVal = _playerWeaponControl.GetDamageVal();
            damageVal *= 2;
            _playerWeaponControl.SetDamageVal(damageVal);
            _damageX2Indicator.SetActive(true);
            StartCoroutine(DamageX2Routine());
            Destroy(this.transform.GetChild(0).gameObject);
            Destroy(this.gameObject, 7.0f);
        }
    }

    IEnumerator DamageX2Routine()
    { 
        yield return new WaitForSeconds(5.0f);
        float damageVal;
        damageVal = _playerWeaponControl.GetDamageVal();
        damageVal /= 2;
        _playerWeaponControl.SetDamageVal(damageVal);
        _damageX2Indicator.SetActive(false);
    }
}
