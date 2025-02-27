using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    public GameObject player;
    public bool moveAble = true;
    public float spd = 2f;
    public float range = 1.5f;
    public GameObject bulletPrefab;
    public float shootingCooldown = 2f;

    private float shooterTimer;
    private float dist;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shooterTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position), range);
        Debug.Log(hit.collider);
        if (hit.collider == null || hit.collider.CompareTag("Player") || hit.collider.CompareTag("Shield"))
        {
            if (dist > range && moveAble)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime);
            }
            else
            {
                if (shooterTimer < Time.time)
                {
                    //Find the player and rotate to it
                    Vector3 direction = player.transform.position - transform.position;
                    direction.Normalize();
                    float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    //Shoot Bullet
                    var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0f, 0f, rotation - 180));
                    shooterTimer = Time.time + shootingCooldown;
                }
            }
        }
    }
}
