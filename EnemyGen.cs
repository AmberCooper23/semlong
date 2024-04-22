using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGen : MonoBehaviour
{
    public Transform trans;
    PositionVar position;
    private Transform CurrentPos;

    public GameObject FlyPrefab;
    public GameObject Fly;

    public float timer = 0f;

    // Start is called before the first frame update

    private struct PositionVar
    {
        public  Transform Pos1, Pos2, Pos3, Pos4;


        public PositionVar(Transform pos1, Transform pos2, Transform pos3, Transform pos4)
        {
            Pos1 = pos1;
            Pos2 = pos2;
            Pos3 = pos3;
            Pos4 = pos4;


        }

    }
    
    void Start()
    {
        trans = GetComponent<Transform>();
        position = new PositionVar(trans.GetChild(0), trans.GetChild(1), trans.GetChild(2), trans.GetChild(3)); 
    }

    private void PosGen(int i)
    {
        if (i == 0)
        {
            CurrentPos= position.Pos1;
        }

        if (i == 1)
        {
            CurrentPos= position.Pos2;
        }

        if (i== 2)
        {
            CurrentPos =  position.Pos3;
        }

        if (i==3)
        {
            CurrentPos = position.Pos4;
        }
    }

  private void EnemyGenerator()
    {
        int Num = Random.Range(0,3);

        PosGen(Num);

        Fly = Instantiate(FlyPrefab, CurrentPos.position, Quaternion.identity);

        Fly.transform.tag = "Enemy";
        Fly.AddComponent<Rigidbody2D>();
        Fly.AddComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (timer == 0f)
        {
            for (int k = 0; k <=3; k++)
            {
                EnemyGenerator();
            }

            timer = 20f;
        }

        if (timer != 0f)
        {
            timer -= Time.deltaTime;
        }
    }
}
