using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Controller : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField, Tooltip("Speed: m/s")] private float _translationSpeed = 1f;
    [SerializeField] private int _activeCountSegment = 10;

    [Header("Component")]
    [SerializeField] private Segment_Controller[] _segmentPool;

    private List<Segment_Controller> _instanciedSegment = new();

    private void Start()
    {
        AddBaseSegment(transform.position); // ajout d'un primier segment au start
    }

    private void Update()
    {
        
    }

    private void AddBaseSegment(Vector3 position)
    {
        for (int i = 0; i < _activeCountSegment; i++) // si aucun segment ou en dessous de la limite, on en instantie un
        {
            if (i == 0) // si aucun segment on en instantie un a "baseSegment" et on continue la boucle
            {
                var baseSegment = AddSegment(transform.position);
                _instanciedSegment.Add(baseSegment);
                continue;
            }

            var segment = AddSegment(LastSegment().EndAnchor); // si il y a deja des segments on les instantie la pos de l'ancre du dernier segment
            _instanciedSegment.Add(segment); // et on l'ajoute a la liste
        }
    }

    private Segment_Controller AddSegment(Vector3 position)
    {
        if (_segmentPool.Length == 0) // si pas de segment dans le pool, alors on fait rien
        {
            return null;
        }

        var index = Random.Range(0, _segmentPool.Length); // sinon choisi un segment random

        Segment_Controller segment = Instantiate(_segmentPool[index], position, Quaternion.identity); // et on l'intantie

        return segment;
    }

    private Segment_Controller LastSegment() // on return le dernier segment
    {
        return _instanciedSegment[_instanciedSegment.Count -1];
    }
}