using UnityEngine; 
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class NawMehsMovement : MonoBehaviour
{
#if UNITY_STANDALONE_WIN
    private enum MouseButton
    {
        Left = 0,
        Right = 1
    }
    [SerializeField] private MouseButton button;
#endif
    [SerializeField] private GameObject endPoint;
    [SerializeField] private bool rayCastActive = true;
    Animator animator;
    NavMeshAgent nawMehs;
    private const int RayLench = 9999;
    private int layermask = 1;

    private void Start()
    {

        endPoint.SetActive(false);
        animator = GetComponent<Animator>();
        nawMehs = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        NavMeshMove();
    }

    private Ray RayCasing()
    {
        Ray ray = new Ray();
        if (rayCastActive == true)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            return ray;
        }
        return ray;
    }

    private void NavMeshMove()
    {
            RaycastHit raycastHit;
            if (Physics.Raycast(RayCasing(), out raycastHit, RayLench, layermask, QueryTriggerInteraction.Ignore) && 
            !EventSystem.current.currentSelectedGameObject &&
#if UNITY_STANDALONE_WIN
            Input.GetMouseButton((int)button)
#endif
#if UNITY_ANDROID
            Input.touchCount > 0
#endif
                )
            {
                nawMehs.SetDestination(raycastHit.point);
                animator.SetFloat("speed", 1);
                endPoint.transform.position = raycastHit.point - new Vector3(0, -0.1f, 0);
                endPoint.SetActive(true);
            }
            if (Vector3.Distance(transform.position, nawMehs.destination) < 1f)
            {
                animator.SetFloat("speed", 0);
                endPoint.SetActive(false);
            }
    }

    public void RayActive(bool isActive) => rayCastActive = isActive == true ? true : false;
}