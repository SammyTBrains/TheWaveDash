using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave4E : Enemy
{
    [SerializeField]
    private float _forwardSpeed = 13.0f, _leftRightSpeed = 5.0f;

    private bool _hasReached1 = false, _hasReached2 = false, _hasReached3 = false;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _forwardSpeed);
        if (this.transform.parent.GetChild(0) == this.transform)
        {
            if (transform.position.x == -15.0f)
            {
                _hasReached1 = false;
            }
            if (transform.position.x == -4.0f)
            {
                _hasReached1 = true;
            }

            if (_hasReached1 == false)
            {
                transform.Translate(Vector3.right * Time.deltaTime * _leftRightSpeed);
            }
            if (_hasReached1)
            {
                transform.Translate(Vector3.left * Time.deltaTime * _leftRightSpeed);
            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -15.0f, -4.0f), transform.position.y, transform.position.z);
        }
        else if (this.transform.parent.GetChild(1) == this.transform)
        {
            if (transform.position.x == 0.0f)
            {
                _hasReached2 = false;
            }
            if (transform.position.x == 9.0f)
            {
                _hasReached2 = true;
            }

            if (_hasReached2 == false)
            {
                transform.Translate(Vector3.right * Time.deltaTime * _leftRightSpeed);
            }
            if (_hasReached2)
            {
                transform.Translate(Vector3.left * Time.deltaTime * _leftRightSpeed);
            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0.0f, 9.0f), transform.position.y, transform.position.z);
        }
        else if (this.transform.parent.GetChild(2) == this.transform)
        {
            if (transform.position.x == 13.0f)
            {
                _hasReached3 = false;
            }
            if (transform.position.x == 22.0f)
            {
                _hasReached3 = true;
            }

            if (_hasReached3 == false)
            {
                transform.Translate(Vector3.right * Time.deltaTime * _leftRightSpeed);
            }
            if (_hasReached3)
            {
                transform.Translate(Vector3.left * Time.deltaTime * _leftRightSpeed);
            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, 13.0f, 22.0f), transform.position.y, transform.position.z);
        }

    }
}
