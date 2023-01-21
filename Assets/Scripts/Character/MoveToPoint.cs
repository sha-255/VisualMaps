using UnityEngine;
using UnityEngine.AI;

public class MoveToPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] pointInstances;
    [SerializeField] private GameObject _endPointRoute;
    [SerializeField] private GameObject disableButton;
    //private Vector3[] metaPoints;
    private bool m_isMove;
    private bool m_isMoveDisable;
    private int m_pointID;
    private NavMeshAgent m_nawMehs;
    private Animator m_animator;

    private void Start()
    {
        //for (var i = 0;i>pointInstances.Length;i++)
        //    metaPoints[i] = pointInstances[i].transform.position/2;
        m_nawMehs = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
    }
    private void Update()
    {
        MoveToEndPoint();
    }

    private void MoveToEndPoint()
    {
        if (m_isMove)
        {
            m_nawMehs.SetDestination(pointInstances[m_pointID].transform.position);

            disableButton.SetActive(true);
            m_animator.SetFloat("speed", 1);
            _endPointRoute.transform.position = pointInstances[m_pointID].transform.position;
            _endPointRoute.SetActive(true);
        }
        //if (Vector3.Distance(transform.position, metaPoints[m_pointID]) < 10f)
        //{
        //    m_nawMehs.SetDestination(pointInstances[m_pointID].transform.position);
        //}
        if (Vector3.Distance(transform.position, pointInstances[m_pointID].transform.position) < 0.3f)
        {
            IsMovable(false);
            IsDisable(true);
        }
        if (m_isMoveDisable)
        {
            m_isMove = false;
            m_isMoveDisable = false;
            _endPointRoute.SetActive(false);
            disableButton.SetActive(false);
            m_animator.SetFloat("speed", 0);
            m_nawMehs.SetDestination(transform.position);
        }
    }

    public void PointID(int ID)
    {
        m_pointID = ID;
        m_pointID -= 1;
    }

    public void IsMovable(bool isStart) => m_isMove = isStart;

    public void IsDisable(bool isDisable) => m_isMoveDisable = isDisable;
}
