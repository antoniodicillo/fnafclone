using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class AnimatronicSystem : MonoBehaviour
{
    [SerializeField] private NavMeshAgent NMA;
    [SerializeField] private GameObject[] Targets;

    [SerializeField] private int CurrentTarget;

    [SerializeField] private float CoolDownTimer;
    [SerializeField] private float MinCoolDownTime;
    [SerializeField] private float MaxCoolDownTime;

    [SerializeField] private int MinChanceToMove;
    [SerializeField] private int MaxChanceToMove;

    [SerializeField] private int ThresholdPass;

    [SerializeField] private int[] AgressionByHour;

    [SerializeField] private int MinAgressionAdd;
    [SerializeField] private int MaxAgressionAdd;

    [SerializeField] private int HoursChanged;

    [SerializeField] private PlayableDirector Director;

    [SerializeField] private Door Door;

    // Start is called before the first frame update
    void Start()
    {
        NMA = GetComponent<NavMeshAgent>();
        CoolDownTimer = MaxCoolDownTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(CoolDownTimer <= 0)
        {
            var chanceCheck = Random.Range(MinChanceToMove, MaxChanceToMove);

            if(chanceCheck <= ThresholdPass)
            {
                if (Vector3.Distance(transform.position, Targets[CurrentTarget].transform.position) <= 1f)
                {
                    if (Targets[CurrentTarget].GetComponent<DestinationPoint>().IsDoor)
                    {
                        if (Targets[CurrentTarget].GetComponent<DestinationPoint>().Door.isOpen)
                        {
                            CurrentTarget = Targets.Length - 1;
                        }
                        else
                        {
                            Door.Audio.clip = Door.Knock;
                            Door.Audio.Play();
                            CurrentTarget = 1;
                            transform.position = Targets[CurrentTarget].transform.position;
                        }
                    }
                    else
                    {
                        CurrentTarget++;
                        if (CurrentTarget >= Targets.Length)
                        {
                            CurrentTarget = 0;
                        }
                    }
                }
            }
            
            var CoolDownTime = Random.Range(MinCoolDownTime, MaxCoolDownTime);
            CoolDownTimer = CoolDownTime;
        }
        else
        {
            CoolDownTimer -= Time.deltaTime;
        }

        if (Targets[CurrentTarget].GetComponent<DestinationPoint>().IsOffice)
        {
            Director.Play();
        }
       

            NMA.destination = Targets[CurrentTarget].transform.position;
    }
    public void ChangeAgressionByHour(int hour)
    {
        if (HoursChanged != hour)
        {
            if (ThresholdPass < hour)
            {
                ThresholdPass = AgressionByHour[hour];
            }
            ThresholdPass += Random.Range(MinAgressionAdd, MaxAgressionAdd);
            HoursChanged++;
        }
        
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
