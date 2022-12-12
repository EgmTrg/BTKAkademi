using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform gun;

    [SerializeField] private Transform shoot_instantiateTransform;
    [SerializeField] private GameObject[] projectiles;

    float angle;
    float rotationSpeed = 5f;

    private void Update()
    {
        ChangeRotate();
    }

    private void ChangeRotate()
    {
        Quaternion rot = default;
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            Shoot();
        }
        rot = Quaternion.AngleAxis(angle, Vector3.forward);
        gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rot, rotationSpeed * Time.deltaTime);
    }

    private void Shoot()
    {
        var local_projectile = Instantiate(projectiles[Random.Range(0, projectiles.Length)], shoot_instantiateTransform.position, shoot_instantiateTransform.rotation) as GameObject;
    }
}
