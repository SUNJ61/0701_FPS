using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//enemy�� �¾�� ������ ���Ҿ� ������ü�� �ƿ츣�� ����� ����, �� ���� ��ü�� ���� Ŭ����
//1. �� ������, 2. �¾ ��ġ 3. �ð� ����(���ʸ��� �¾�°�) 4. ��� ���� �¾�°�
public class GameManager : MonoBehaviour
{
    public GameObject Zom_fb; //1��
    public GameObject Monster_fb;
    public GameObject Skel_fb;
    public Transform[] point; //2��

    private float timePrev_Z; //3�� - ���� �ڿ�
    private float timePrev_M; //�迭�� ������ ����ҵ�
    private float timePrev_S;

    private float SpawnTime_Z = 3.0f; //3�� - 3�ʰ���
    private float SpawnTime_M = 8.0f;
    private float SpawnTime_S = 5.0f;

    private int MaxCount_Z = 10; //4��
    private int MaxCount_M = 3;
    private int MaxCount_S = 5;

    private string Zom = "ZOMBIE";
    private string Mon = "MONSTER";
    private string Skel = "SKELETON";
    private string SP = "SpawnPoints";
    void Start()
    {
        //���̶�Ű���� SpawnPoints��� ������Ʈ�� ã�� �� ������Ʈ�� ���� ��ġ ������Ʈ���� �����Ѵ�.(##�ڱ� �ڽ���ġ ���� ����##)
        point = GameObject.Find(SP).GetComponentsInChildren<Transform>(); //���� �Ҵ�
        timePrev_Z = Time.time; // ������Ʈ�� �������� ���Žð��� ��.
        timePrev_M = Time.time;
        timePrev_S = Time.time;
    }


    void Update()
    {
        Spawn_Zom();
        Spawn_Mon();
        Spawn_Skel();
    }

    private void Spawn_Skel()
    {
        if (Time.time - timePrev_S > SpawnTime_S)
        {
            int Skelcounter = GameObject.FindGameObjectsWithTag(Skel).Length;
            if (Skelcounter < MaxCount_S)
            {
                int randPos_S = Random.Range(1, point.Length);
                Instantiate(Skel_fb, point[randPos_S].position, point[randPos_S].rotation);
                timePrev_S = Time.time;
            }
        }
    }

    private void Spawn_Mon()
    {
        if (Time.time - timePrev_M > SpawnTime_M)
        {
            int Moncounter = GameObject.FindGameObjectsWithTag(Mon).Length;
            if (Moncounter < MaxCount_M)
            {
                int randPos_M = Random.Range(1, point.Length);
                Instantiate(Monster_fb, point[randPos_M].position, point[randPos_M].rotation);
                timePrev_M = Time.time;
            }
        }
    }

    private void Spawn_Zom()
    {
        if (Time.time - timePrev_Z >= SpawnTime_Z)
        {
            //���̶�Ű���� ���� �±׸� ���� ������Ʈ�� ������ ī��Ʈ�ؼ� �ѱ�
            int Zomcounter = GameObject.FindGameObjectsWithTag(Zom).Length;
            if (Zomcounter < MaxCount_Z)
            {
                int randPos_Z = Random.Range(1, point.Length);
                Instantiate(Zom_fb, point[randPos_Z].position, point[randPos_Z].rotation);
                timePrev_Z = Time.time; //���Žð� ������Ʈ
            }
        }
    }
}
