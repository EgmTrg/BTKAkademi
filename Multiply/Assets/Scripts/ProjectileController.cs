using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    private float _speed = 5f;

    void Start()
    {
        if (this.gameObject != null)
        {
            Destroy(this.gameObject, 3f);
        }
    }

    void Update()
    {
        this.gameObject.transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }
}
