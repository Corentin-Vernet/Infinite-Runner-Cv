using UnityEngine;
using System.Collections;

public class Player_Collision_Controller : MonoBehaviour
{
    [SerializeField] private float invinsibilityTime = 1f;
    [SerializeField] private bool invinsibility = false;

    private void OnCollisionEnter(Collision collision)
    {
        //StartCoroutine(routine: AfterHitCoroutine());
        print("touché !");

        EventSystem.OnPlayerCollision?.Invoke();
    }

    public void OnTriggerEnter(Collider other)
    {
        print("Transpercé !");
    }

    private IEnumerator AfterHitCoroutine()
    {
        BoxCollider box = GetComponent<BoxCollider>();

        invinsibility = true;
        box.enabled = false;
        yield return new WaitForSeconds(invinsibilityTime);
        box.enabled = true;
        invinsibility = false;
    }
}