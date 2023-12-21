using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{

    public bool hasBeenDestroyed = false;
    public float speed = 1f; // Ўвидк≥сть руху пр€мокутника
    private GameObject player;
    private bool isLying = false;
    public UnityEvent OnDestroyed;
    private int hitCount = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // ѕерев≥рка, чи пр€мокутник впав (Rotation Z близько до 90 або до 270)
        if (!hasBeenDestroyed && transform.rotation.eulerAngles.z > 260f && transform.rotation.eulerAngles.z < 280f ||
            !hasBeenDestroyed && transform.rotation.eulerAngles.z > 80f && transform.rotation.eulerAngles.z < 100f)
        {
            isLying = true;
            // «нищенн€ пр€мокутника
            Destroy(gameObject, 2);
            hasBeenDestroyed = true;
        }

        if (!hasBeenDestroyed && !isLying)
        {
            if (player != null)
            {
                // ќбчисленн€ напр€мку до гравц€
                Vector3 direction = player.transform.position - transform.position;
                direction.Normalize(); // Ќормал≥зац≥€ вектору дл€ отриманн€ одиничного напр€мку

                // –ух пр€мокутника в напр€мку гравц€
                transform.Translate(direction * speed * Time.deltaTime);
            }
        }
    }

    void OnDestroy()
    {
        // ¬икликаЇмо под≥ю при знищенн≥ пр€мокутника
        OnDestroyed.Invoke();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // якщо снар€д попав в пр€мокутник, зб≥льшити л≥чильник
            hitCount++;

            // ѕерев≥рити, чи дос€гнуто необх≥дну к≥льк≥сть попадань
            if (hitCount >= 5)
            {
                // ¬икликати под≥ю при знищенн≥ пр€мокутника
                //OnDestroyed.Invoke();

                // «нищити пр€мокутник
                Destroy(gameObject);
            }
        }
    }
}
