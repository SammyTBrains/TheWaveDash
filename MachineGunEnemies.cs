using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunEnemies : MonoBehaviour
{
    [SerializeField]
    private float _damageVal;
    [SerializeField]
    private GameObject _muzzleFlash, _hitParticles;
    [SerializeField]
    private AudioClip _gunShot;

    // Update is called once per frame
    void Update()
    {
        Firing();
    }

    private void Firing()
    {
        Vector3 pos = this.transform.position;
        pos.z += 1.0f;
        RaycastHit hit;

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit))
        {  
            if (hit.transform.gameObject.tag == "Player")
            {
                ShootingEffects(hit, pos);
                hit.transform.gameObject.GetComponent<Player>().DamageHandler(_damageVal);
            }
        }
    }

    private void ShootingEffects(RaycastHit hit, Vector3 pos)
    {
        GameObject mFlash = Instantiate(_muzzleFlash, pos, Quaternion.identity);
        mFlash.transform.parent = this.transform;
        AudioSource.PlayClipAtPoint(_gunShot, Camera.main.transform.position);
        mFlash.transform.rotation = this.transform.rotation;
        Vector3 tempRot = mFlash.transform.localEulerAngles;
        tempRot.y -= 90;
        mFlash.transform.localEulerAngles = tempRot;
        GameObject hitPt = Instantiate(_hitParticles, hit.point, Quaternion.identity);
        Destroy(mFlash, 0.5f);
        Destroy(hitPt, 1.0f);
    }
}
