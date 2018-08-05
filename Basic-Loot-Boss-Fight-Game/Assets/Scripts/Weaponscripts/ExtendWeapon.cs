using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendWeapon : MonoBehaviour {

    [SerializeField]
    float _sizeIncrease = 2;

    bool _isExtended = false;
    Vector3 _startingScale;
    Vector3 _extendedScale;

    [SerializeField]
    float _extendingRate = 2f;
    [SerializeField]
    float _extendingTimer = Mathf.Clamp(0f,0f,1f);

	void Start ()
    {
        _startingScale = gameObject.transform.localScale;
        _extendedScale = new Vector3( _startingScale.x,_startingScale.y ,_startingScale.z * _sizeIncrease);
	}
	
	void Update ()
    {
        _extendedScale = new Vector3(_startingScale.x, _startingScale.y, _startingScale.z * _sizeIncrease);

        if (_extendingTimer > 1f)
            _extendingTimer = 1f;

        if (_extendingTimer < 0.0f)
            _extendingTimer = 0.0f;

        if (_isExtended)// checking if is is extending
        {
            _extendingTimer += Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Lerp(_startingScale.z, _extendedScale.z, _extendingTimer * _extendingRate));
        }
        if (!_isExtended)// checking if is is retracting
        {
            _extendingTimer -= Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Lerp(_startingScale.z, _extendedScale.z, _extendingTimer * _extendingRate));
        }

        if (!_isExtended && Input.GetKeyDown(KeyCode.Alpha1))
        {
            _isExtended = true;
        }
        else if (_isExtended && Input.GetKeyDown(KeyCode.Alpha1))
        {
            _isExtended = false;
        }
	}
}
