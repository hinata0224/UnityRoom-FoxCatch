using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField, Range(10, 50)] private float runAwatDistance = 30f;

    private bool chach = false;

    private NavMeshAgent agent;

    private Animator animator;

    private readonly ReactiveProperty<bool> reactiveProperty = new ReactiveProperty<bool>();
    private Subject<string> animationivent = new Subject<string>();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        reactiveProperty.Where(isNear => !isNear)
            .Subscribe(_ => SetRandomDestinationAsync(this.GetCancellationTokenOnDestroy()).Forget())
            .AddTo(this);
        animationivent.Subscribe(msg => AnimtionDisolacement(msg))
            .AddTo(this);
    }

    void Update()
    {
        if (reactiveProperty.Value)
        {
            Debug.Log("zikkou");
            animationivent.OnNext("RunEnd");
        }
    }

    private void AnimtionDisolacement(string ivent)
    {
        switch (ivent)
        {
            case "RunStart":
                animator.SetBool("Run", true);
                break;
            case "RunEnd":
                animator.SetBool("Run", false);
                break;
            case "Jump":
                chach = true;
                agent.isStopped = true;
                animator.SetTrigger("Jump");
                break;
            default:
                break;
        }
    }

    private async UniTask SetRandomDestinationAsync(CancellationToken ct)
    {
        while (!reactiveProperty.Value && !chach)
        {
            var randomValue = Random.Range(-100, 100);
            if (agent == null)
            {
                return;
            }
            agent.SetDestination(new Vector3(randomValue, 0, randomValue));
            await UniTask.Delay(TimeSpan.FromSeconds(10f), cancellationToken: ct);
            animationivent.OnNext("RunStart");
        }
    }

    public void CatchFox()
    {
        animationivent.OnNext("Jump");
    }
}
