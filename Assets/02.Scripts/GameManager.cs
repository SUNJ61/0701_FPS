using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//enemy가 태어나는 로직과 더불어 게임전체를 아우르는 기능을 조정, 즉 게임 전체를 조정 클래스
//1. 적 프리팹, 2. 태어날 위치 3. 시간 간격(몇초마다 태어나는가) 4. 몇마리 까지 태어나는가
public class GameManager : MonoBehaviour
{
    public GameObject Zom_fb; //1번
    public GameObject Monster_fb;
    public GameObject Skel_fb;
    public Transform[] point; //2번

    private float timePrev_Z; //3번 - 몇초 뒤에
    private float timePrev_M; //배열로 묶으면 깔끔할듯
    private float timePrev_S;

    private float SpawnTime_Z = 3.0f; //3번 - 3초간격
    private float SpawnTime_M = 8.0f;
    private float SpawnTime_S = 5.0f;

    private int MaxCount_Z = 10; //4번
    private int MaxCount_M = 3;
    private int MaxCount_S = 5;

    private string Zom = "ZOMBIE";
    private string Mon = "MONSTER";
    private string Skel = "SKELETON";
    private string SP = "SpawnPoints";
    void Start()
    {
        //하이라키에서 SpawnPoints라는 오브젝트를 찾고 그 오브젝트의 속한 위치 컴포넌트들을 저장한다.(##자기 자신위치 정보 포함##)
        point = GameObject.Find(SP).GetComponentsInChildren<Transform>(); //동적 할당
        timePrev_Z = Time.time; // 업데이트로 내려가면 과거시간이 됨.
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
            //하이라키에서 몬스터 태그를 가진 오브젝트의 갯수를 카운트해서 넘김
            int Zomcounter = GameObject.FindGameObjectsWithTag(Zom).Length;
            if (Zomcounter < MaxCount_Z)
            {
                int randPos_Z = Random.Range(1, point.Length);
                Instantiate(Zom_fb, point[randPos_Z].position, point[randPos_Z].rotation);
                timePrev_Z = Time.time; //과거시간 업데이트
            }
        }
    }
}
