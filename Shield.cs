using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private GameObject _shieldModel;   
    private GameObject _shieldIndicator;

    private void Start()
    {
        _shieldModel = GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject;
        _shieldIndicator = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(7).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.gameObject.GetComponent<Player>();

            if(player != null)
            {
                _shieldIndicator.SetActive(true);
                _shieldModel.SetActive(true);
                player.SetShielded(true);
                StartCoroutine(DamageX2Routine(player));
                Destroy(this.transform.GetChild(0).gameObject);
                Destroy(this.gameObject, 7.0f);
            }         
        }
    }

    IEnumerator DamageX2Routine(Player player)
    {
        yield return new WaitForSeconds(5.0f);
        player.SetShielded(false);
        _shieldIndicator.SetActive(false);
        _shieldModel.SetActive(false);
    }
}
