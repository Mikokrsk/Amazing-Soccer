using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WheelOfFortune : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private RectTransform _wheelTransform;
    [SerializeField] private GameObject _sectorPrefab;
    [SerializeField] private AnimationCurve _spinCurve;

    private List<SectorBounds> _sectorBounds = new List<SectorBounds>();

    private int _numberOfSectors = 8;
    [SerializeField] private int _minCostGift;
    [SerializeField] private int _maxCostGift;
    [SerializeField] private float _spinDuration = 3f;

    [SerializeField] private bool _isSpinning = false;

    void Start()
    {
        GenerateSectors(2);
    }

    public void GenerateSectors(int sectorsCount)
    {
        _numberOfSectors = (int)Mathf.Clamp(sectorsCount, 2, 12);
        ClearSectors();
        _wheelTransform.transform.rotation = Quaternion.Euler(0, 0, 0);
        float sectorAngle = 360f / _numberOfSectors;

        for (int i = 0; i < _numberOfSectors; i++)
        {
            GameObject newSector = Instantiate(_sectorPrefab, _wheelTransform.transform);
            Image sectorImage = newSector.GetComponent<Image>();

            sectorImage.type = Image.Type.Filled;
            sectorImage.fillMethod = Image.FillMethod.Radial360;
            sectorImage.fillOrigin = 2;


            sectorImage.fillAmount = 1f / _numberOfSectors;
            newSector.transform.localPosition = Vector3.zero;
            newSector.transform.localRotation = Quaternion.Euler(0, 0, -sectorAngle * i);

            RectTransform rectTransform = newSector.GetComponent<RectTransform>();
            rectTransform.pivot = new Vector2(0.5f, 0.5f);

            var prize = newSector.GetComponentInChildren<Gift>();
            prize.SetCost(UnityEngine.Random.Range(_minCostGift, _maxCostGift));

            var newPirzeAngle = -180 * sectorImage.fillAmount;
            prize.SetRotation(newPirzeAngle);


            float sectorStartAngle = sectorAngle * i;
            float sectorEndAngle = sectorAngle * (i + 1);

            sectorEndAngle = (sectorEndAngle + 360) % 360;
            sectorStartAngle = (sectorStartAngle + 360) % 360;

            if (i + 1 == _numberOfSectors)
            {
                sectorEndAngle = 360f;
            }

            _sectorBounds.Add(new SectorBounds(prize, sectorStartAngle, sectorEndAngle));
        }
    }

    void ClearSectors()
    {
        foreach (Transform child in _wheelTransform.transform)
        {
            Destroy(child.gameObject);
        }

        _sectorBounds.Clear();
    }


    public void SpinWheel()
    {
        if (!_isSpinning)
        {
            _closeButton.interactable = false;
            StartCoroutine(Spin());
        }
    }

    private IEnumerator Spin()
    {
        _isSpinning = true;
        float elapsedTime = 0f;
        var wheelAngleZ = Mathf.Repeat(_wheelTransform.transform.eulerAngles.z, 360f);
        float startAngle = wheelAngleZ;
        float endAngle = startAngle + 360f * UnityEngine.Random.Range(3f, 15f);

        while (elapsedTime < _spinDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / _spinDuration;
            float angle = Mathf.Lerp(startAngle, endAngle, _spinCurve.Evaluate(t));
            angle = Mathf.Repeat(angle, 360f);
            _wheelTransform.transform.eulerAngles = new Vector3(0, 0, angle);
            yield return null;
        }

        _isSpinning = false;
        var gift = DetermineWinningSector();
        _closeButton.interactable = true;
        UIManager.Instance.OpenSummaryMenu(gift.GetCost());
    }

    public Gift DetermineWinningSector()
    {
        var wheelAngleZ = Mathf.Repeat(_wheelTransform.transform.eulerAngles.z, 360f);
        foreach (var sectorBound in _sectorBounds)
        {
            if (wheelAngleZ >= sectorBound.startAngle && wheelAngleZ < sectorBound.endAngle)
            {
                return sectorBound.prize;
            }
        }

        Debug.Log(wheelAngleZ);
        return null;
    }

    [Serializable]
    public class SectorBounds
    {
        public Gift prize;
        public float startAngle;
        public float endAngle;

        public SectorBounds(Gift prize, float startAngle, float endAngle)
        {
            this.prize = prize;
            this.startAngle = startAngle;
            this.endAngle = endAngle;
        }
    }
}