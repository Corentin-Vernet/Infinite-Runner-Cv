using UnityEngine;

public class Segment_Controller : MonoBehaviour
{
    [SerializeField] private Transform _endAnchor;

    public Vector3 EndAnchor => _endAnchor.position; // "=>" (c'est un "getter") qui sert a rendre publique une variable privé

    public bool IsBehindPlayer()
    {
        return EndAnchor.z < 0;
    }
}
