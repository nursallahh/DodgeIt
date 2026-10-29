using UnityEngine;

public class XParkourFollowedByTimeTrigger : MonoBehaviour
{
    [SerializeField] XParkourObstacleTimerFollowed[] rollingXParkourObstacle;
    [SerializeField] Vector3[] rollingPos;
    Vector3[] targetPosition;
    Vector3[] previousPosition;
    bool started;
    float nextMoveTime;

    void OnTriggerEnter(Collider other)
    {
        Rigidbody playerBody = other.attachedRigidbody;
        if (started || playerBody == null || !playerBody.CompareTag("PlayerObject")) return;

        foreach (XParkourObstacleTimerFollowed child in rollingXParkourObstacle)
        {
            if (child != null) child.gameObject.SetActive(true);
        }

        targetPosition = new Vector3[rollingXParkourObstacle.Length];
        previousPosition = new Vector3[rollingXParkourObstacle.Length];

        for (int i = 0; i < rollingXParkourObstacle.Length; i++)
        {
            if (rollingXParkourObstacle[i] == null) continue;

            previousPosition[i] = rollingXParkourObstacle[i].transform.position;
            if (i % 2 == 0)
                targetPosition[i] = previousPosition[i] + rollingPos[i];
            else
                targetPosition[i] = previousPosition[i] + rollingPos[i];
        }

        nextMoveTime = Time.time + 1f;
        started = true;
    }

    void Update()
    {
        if (!started || Time.time < nextMoveTime) return;

        bool allReached = true;
        for (int i = 0; i < rollingXParkourObstacle.Length; i++)
        {
            if (rollingXParkourObstacle[i] == null) continue;

            rollingXParkourObstacle[i].transform.position = Vector3.MoveTowards(
                rollingXParkourObstacle[i].transform.position,
                targetPosition[i],
                XParkourObstacleTimerFollowed.XparkourObstacleRollingSpeed * Time.deltaTime
            );

            if (rollingXParkourObstacle[i].transform.position != targetPosition[i])
                allReached = false;
        }

        if (allReached)
        {
            // Bir sonraki harekette geldikleri noktaya geri dönsünler.
            for (int i = 0; i < rollingXParkourObstacle.Length; i++)
            {
                Vector3 reachedPosition = targetPosition[i];
                targetPosition[i] = previousPosition[i];
                previousPosition[i] = reachedPosition;
            }

            nextMoveTime += 1f;
        }
    }
}
