using UnityEngine.AI;
using UnityEngine;

public class RunToThePoint : MonoBehaviour
{
    [SerializeField] private GameObject[] endPoints;
    private Vector3[] startEndPoints;
    [SerializeField] private GameObject disableGameButton;
    Animator animator;
    NavMeshAgent nawMehs;
    [SerializeField] private bool isRunning;
    private int isRunningID;
    [SerializeField] private bool isDisable;
    [SerializeField] private GameObject _endPointRoute;
    private bool Last = false;

    private void Start()
    {
        startEndPoints = new Vector3[endPoints.Length];
        for (int i = 0; i < endPoints.Length; i++)
        {
            startEndPoints[i] = endPoints[i].transform.position;
        }
        //endPointRoute = GameObject.Find("/labelEndPointRoute");
        animator = GetComponent<Animator>();
        nawMehs = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //Debug.Log(Last);
        if (isRunning)
        {
            Last = false;

            if (!Last)
            RunToPoint(startEndPoints[isRunningID],true);
        }
        if (Last)
        {
            if (Vector3.Distance(transform.position, startEndPoints[isRunningID]) < 1f)
            {
                isRunning = false;
                animator.SetFloat("speed", 0);
                disableGameButton.SetActive(false);
            }
        }
        if (isDisable)
        {
            animator.SetFloat("speed", 0);
            nawMehs.SetDestination(transform.position);
            _endPointRoute.SetActive(false);
            isDisable = false;
        }
    }
    private void RunToPoint(Vector3 pointCoordinate, bool isLast)
    {
        disableGameButton.SetActive(true);
        animator.SetFloat("speed", 1);
        Last = isLast;
        _endPointRoute.transform.position = pointCoordinate;
        nawMehs.SetDestination(pointCoordinate);
        _endPointRoute.SetActive(true);
    }

    public void ChangeIsRunning(bool isRun)
    {
        isRunning = isRun;
    }
    public void ChangeIsRunningID(int ID) 
    { 
        isRunningID = ID;
        isRunningID -= 1;
    }
    public void ChangeisDisable(bool isDisabl)
    {
        isDisable = isDisabl;
    }
}
