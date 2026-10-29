using UnityEngine;

public class Scorer : MonoBehaviour
{
    private int counter = 0;

    public void IncreaseCounter()
    {
        counter++;
        Debug.Log($"You have bumped into {counter} different obstacles");
    }
}