using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLifespan : MonoBehaviour {

    [SerializeField]
    float _lifespan;

    float _lifeTimer;

	void Start () {
        _lifeTimer = 0.0f;
	}
	
	void Update () {
        _lifeTimer += Time.deltaTime;
		if(_lifeTimer >= _lifespan)
        {
            Destroy(gameObject);
        }
	}
}
