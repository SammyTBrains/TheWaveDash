using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponControl : MonoBehaviour
{
    [SerializeField]
    private Transform _cylinder;
    [SerializeField]
    private Joystick _joystick;
    [SerializeField]
    private int _sensitivity = 12;
    [SerializeField]
    private float _damageVal = 0.5f;
    [SerializeField]
    private GameObject _muzzleFlash, _hitParticles;
    [SerializeField]
    private AudioClip _gunShot;
    [SerializeField]
    private GameObject _player;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Aim();       
    }

    private void Aim()
    {
        float horizontal = _joystick.Horizontal;
        float vertical = _joystick.Vertical;
        Vector3 pos = _cylinder.position;
        pos.z += 1.0f;

        Vector3 moveVector = (Vector3.up * horizontal + Vector3.left * vertical);
        if (horizontal != 0 || vertical != 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(_cylinder.position, _cylinder.forward, out hit))
            {
                ShootingEffects(hit, pos);
                if (hit.transform.gameObject.tag == "Wave1E")
                {
                    hit.transform.parent.gameObject.GetComponent<Wave1E>().DamageHandler(_damageVal);
                }
                else if (hit.transform.tag == "Wave2EMachineGun")
                {
                    hit.transform.parent.gameObject.GetComponent<Wave2EMachineGun>().DamageHandler(_damageVal);
                }
                else if (hit.transform.tag == "Wave2ERocketLauncher")
                {
                    hit.transform.parent.gameObject.GetComponent<Wave2ERocketLauncher>().DamageHandler(_damageVal);
                }
                else if (hit.transform.tag == "Wave3E")
                {
                    hit.transform.parent.gameObject.GetComponent<Wave3E>().DamageHandler(_damageVal);
                }
                else if (hit.transform.tag == "Wave4E")
                {
                    hit.transform.parent.gameObject.GetComponent<Wave4E>().DamageHandler(_damageVal);
                }
            }
            _cylinder.rotation = Quaternion.Euler(new Vector3(moveVector.x, moveVector.y, 0) * _sensitivity);
        }
    }

    public float GetDamageVal()
    {
        return _damageVal;
    }

    public void SetDamageVal(float damageVal)
    {
        _damageVal = damageVal;
    }
    private void ShootingEffects(RaycastHit hit, Vector3 pos)
    {
        GameObject mFlash = Instantiate(_muzzleFlash, pos, Quaternion.identity);
        mFlash.transform.parent = _cylinder;
        AudioSource.PlayClipAtPoint(_gunShot, Camera.main.transform.position);
        mFlash.transform.rotation = _cylinder.rotation;
        Vector3 tempRot = mFlash.transform.localEulerAngles;
        tempRot.y -= 90;
        mFlash.transform.localEulerAngles = tempRot;
        GameObject hitPt = Instantiate(_hitParticles, hit.point, Quaternion.identity);
        Destroy(mFlash, 0.5f);
        Destroy(hitPt, 1.0f);
    }
}
