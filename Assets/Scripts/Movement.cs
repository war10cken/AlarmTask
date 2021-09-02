using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(_speed * Time.deltaTime, 0, 0));
            _spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-_speed * Time.deltaTime, 0, 0));
            _spriteRenderer.flipX = true;
        }
    }
}
