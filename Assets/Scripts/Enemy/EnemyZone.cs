using UnityEngine;
using UnityEngine.AI;

public class EnemyZone : MonoBehaviour
{
    Enemy _enemy;
    Animator _anim;
    EnemyPartol _enemyPartol;
    EnemyZone _zone;

    [Header("NavMesh")]
    public NavMeshAgent _agentNavMesh;
    public GameObject _targetPlayer;

    [Header("Zone UI")]
    [SerializeField] private float _moveRadius = 4f;
    [SerializeField] private float _attackRadius = 10f;
    [SerializeField] private float _meleeAttack = 5f;
    //[SerializeField] private int _viewAngle = 90;

    [Header("Attack UI")]
    [SerializeField] private float _hitNexAttack;
    [SerializeField] private float _hitRangeRotate;

    Vector3 _startPos;
    float _distanceToPlayer;
    

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _anim = GetComponent<Animator>();
        _agentNavMesh = GetComponent<NavMeshAgent>();
        _enemyPartol = GetComponent<EnemyPartol>();
        _zone = GetComponent<EnemyZone>();
    }

    private void Start()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        DistanceEnemy();
    }

    private void DistanceEnemy()
    {
        _distanceToPlayer = Vector3.Distance(transform.position, Player.Instance.transform.position);


        if (_enemy._enemyHealth > 0)
        {
            if (_distanceToPlayer > _moveRadius)
            {
                _anim.SetFloat("EnemyRun", 1);

                _enemyPartol.enabled = true;
                _agentNavMesh.isStopped = false;
            }

            if (_distanceToPlayer < _moveRadius)
            {
                Rotate();

                _anim.SetFloat("EnemyRun", 1);

                _enemyPartol.enabled = false;
                _agentNavMesh.SetDestination(_targetPlayer.transform.position);

            }

            if (_distanceToPlayer < _attackRadius)
            {
                _anim.SetFloat("EnemyRun", 0);

                _agentNavMesh.isStopped = true;


                _hitNexAttack -= Time.deltaTime;
                if (_hitNexAttack < 0)
                {
                    _enemy.EnemyShooting();
                    _hitNexAttack = _hitRangeRotate;
                }

            }

        }
        else
        {
            _agentNavMesh.isStopped = true;
            return;
        }

    }

    //private bool CheckToMovePlayer()
    //{
    //    Vector3 directionToPlayer = Player.Instance.transform.position - transform.position;
    //    Debug.DrawRay(transform.position, directionToPlayer, Color.red);

    //    float angle = Vector3.Angle(-transform.up, directionToPlayer);
    //    if (angle > _viewAngle / 2)
    //    {
    //        return false;
    //    }

    //    LayerMask layerMask = LayerMask.GetMask("Walls");
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, directionToPlayer.magnitude, layerMask);
    //    if (hit.collider != null) //проверка на столкновение с преградой
    //    {
    //        //есть коллайдер
    //        return false;
    //    }

        
    //    return true;
    //}

    public void Rotate()
    {
        if (_enemy._enemyHealth > 0)
        {
            Vector3 direction = Player.Instance.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 5f * Time.deltaTime);
        }
        else
        {
            return;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _attackRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _moveRadius);
    }

}
