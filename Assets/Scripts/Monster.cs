using UnityEngine;

public class PointsMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _pointsContainer;

    private int nextPlace;
    private Transform[] _points;

    private void Awake()
    {
        _points = new Transform[_pointsContainer.childCount];

        for (int i = 0; i < _pointsContainer.childCount; i++)
        {
            _points[i] = _pointsContainer.GetChild(i);
        }
    }

    private void Update()
    {
        Transform nextPoint = _points[nextPlace];

        if (transform.position == nextPoint.position)
        {
            DetermineVector();
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, _speed * Time.deltaTime);
    }

    private void DetermineVector()
    {
        nextPlace = ++nextPlace % _points.Length;

        Vector3 moveDerection = _points[nextPlace].transform.position;
        transform.right = moveDerection - transform.position;
    }
}