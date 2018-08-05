using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCommand : MonoBehaviour {

    Animator _playerAnim;

    [SerializeField]
    AudioClip _qSwingSound;

    [SerializeField]
    float _qCooldown = 1f;

    float _qTimer;

	void Start ()
    {
        _playerAnim = GetComponent<Animator>();

        _qTimer = _qCooldown;
	}
	
	// Update is called once per frame
	void Update ()
    {

        HorizontalSwing();

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W was pressed");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E was pressed");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R was pressed");
        }
    }

    void HorizontalSwing()
    {
        _qTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q) && _qTimer >= _qCooldown)
        {
            Debug.Log("Q was pressed");
            _playerAnim.SetTrigger("HorizontalAttack");
            AudioSource.PlayClipAtPoint(_qSwingSound, gameObject.transform.position);
            _qTimer = 0.0f;
        }

        if(_qTimer >= 1f)
        {
            _playerAnim.ResetTrigger("HorizontalAttack");
        }
    }
}
