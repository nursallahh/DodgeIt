using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    public Scorer scorer;


    void Awake()
    {
       scorer = GetComponent<Scorer>();
    }

    private void OnCollisionEnter(Collision whatYouBumpedInto)
    {
        MeshRenderer renderer = whatYouBumpedInto.gameObject.GetComponent<MeshRenderer>();
        void colorChange(ref MeshRenderer renderer)
        {
            renderer.material.color = Color.black;
            renderer.material.SetFloat("_Metallic", 0f);
            renderer.material.SetFloat("_Smoothness", 0f);
        }


        if (whatYouBumpedInto.gameObject.CompareTag("Uninteractable") || whatYouBumpedInto.gameObject.CompareTag("GotHit"))
        {
            return;
        }


        if (renderer != null)
        {
            colorChange(ref renderer);
            whatYouBumpedInto.gameObject.tag = "GotHit";
        }

        scorer.IncreaseCounter();
    }



}