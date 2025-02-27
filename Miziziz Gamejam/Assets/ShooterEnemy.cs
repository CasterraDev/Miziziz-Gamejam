using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    public GameObject player;
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

        if (dist > range)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime);
        }
        else
        {
            if (shooterTimer < Time.time)
            {
                var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                var moveDir = (player.transform.position - transform.position).normalized * spd;
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDir.x, moveDir.y);
                Vector3 rot = (player.transform.position - transform.position);
                bullet.transform.rotation = ;
                shooterTimer = Time.time + shootingCooldown;
            }
        }
    }
}
