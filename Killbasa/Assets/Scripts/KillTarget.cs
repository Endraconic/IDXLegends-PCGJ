using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class KillTarget : MonoBehaviour
{

    public enum EnemyType { Fatty, Lean, Rich }
    public EnemyType enemyType;

    public float fattyLifespan;
    public float leanLifespan;
    public float richLifespan;

    public float leanChance;
    public float richChance;

    public int direction;
    public float movementSpeed;


    public KillGameManager manager;
    public float lifespan;
    public bool isCop = false;



    private float lifeTimer = 0.0f;

    private void Start()
    {
        if (isCop)
            GetComponent<SpriteRenderer>().color = Color.red;
        else
            GetComponent<SpriteRenderer>().color = Color.green;

        //set enemy type here
        float r = Random.Range(0.0f, 100.0f);
        if (r < richChance)
        {
            enemyType = EnemyType.Rich;
            lifespan = richLifespan;
        }
        else if (r < leanChance)
        {
            enemyType = EnemyType.Lean;
            direction = Random.Range(0, 2) * 2 - 1;
            movementSpeed = 1.0f;

            lifespan = leanLifespan;
        }
        else
        {
            enemyType = EnemyType.Fatty;
            lifespan = fattyLifespan;
        }

    }

    private void Update()
    {
        lifeTimer += Time.deltaTime;

        switch (enemyType)
        {
            case EnemyType.Rich:

                break;

            case EnemyType.Lean:

                transform.position += new Vector3(direction, 0, 0) * Time.deltaTime * movementSpeed;

                break;

            case EnemyType.Fatty:
                transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                break;
        }



        if (lifeTimer > lifespan)
            Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (isCop)
            manager.TargetClickedBad();
        else
            manager.TargetClickedGood();

        Destroy(gameObject);
    }
}
