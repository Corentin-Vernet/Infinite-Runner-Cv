using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Controller : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField, Tooltip("Speed: m/s")] private float _translationSpeed = 1f;
    [SerializeField] private int _activeCountSegment = 10;
    [SerializeField] private int _behindCountSegment = 1;

    [Header("Component")]
    [SerializeField] private Segment_Controller[] _segmentPool;

    private List<Segment_Controller> _instancedSegment = new();

    private void Start()
    {
        AddBaseSegment(transform.position); // ajout d'un primier segment au start
    }

    private void Update()
    {
        foreach (var segment in _instancedSegment) // pour déplacer les segments vers l'arrière
        {
            segment.transform.Translate(Vector3.back * _translationSpeed * Time.deltaTime);
        }

        UpdateSegment();
    }

    private void UpdateSegment()
    {
        List<Segment_Controller> segmentBack = new();

        foreach (var segment in _instancedSegment)
        {
            if (segment.IsBehindPlayer()) // si un segment est derrière a la liste des segmentBack
            {
                segmentBack.Add(segment);
            }
        }

        if (segmentBack.Count > _behindCountSegment) // si il y a plus de 2 segment, on delete le premier
        {
            int segmentDeleteCount = segmentBack.Count - _behindCountSegment;

            for (int i = 0; i < segmentDeleteCount; i++)
            {
                var segmentDelete = segmentBack[i];
                _instancedSegment.Remove(segmentDelete);
                Destroy(segmentDelete.gameObject);
            }
        }

        int missingSegmentCount = _activeCountSegment - _instancedSegment.Count;
        for (int i = 0; i < missingSegmentCount; i++)
        {
            var segment = AddSegment(LastActiveSegment().EndAnchor);
            _instancedSegment.Add(segment);
        }
    }

    private void AddBaseSegment(Vector3 position)
    {
        for (int i = 0; i < _activeCountSegment; i++) // si aucun segment ou en dessous de la limite, on en instantie un
        {
            if (i == 0) // si aucun segment on en instantie un a "baseSegment" et on continue la boucle
            {
                var baseSegment = AddSegment(transform.position);
                _instancedSegment.Add(baseSegment);
                continue;
            }

            var segment = AddSegment(LastActiveSegment().EndAnchor); // si il y a deja des segments on les instantie la pos de l'ancre du dernier segment
            _instancedSegment.Add(segment); // et on l'ajoute a la liste
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

    private Segment_Controller LastActiveSegment() // on return le dernier segment
    {
        return _instancedSegment[_instancedSegment.Count -1];
    }
}