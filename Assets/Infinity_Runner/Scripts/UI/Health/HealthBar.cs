using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartTemplate;

    private List<Heart> _herts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanger;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanger;
    }

    private void OnHealthChanger(int value)
    {
        if(_herts.Count < value)
        {
            int createHealth = value - _herts.Count;
            for (int i = 0; i < createHealth; i++)
            {
                CreatHeart();
            }
        }
        else if(_herts.Count > value && _herts.Count !=0)
        {
            int deletHealth = _herts.Count - value;
            for (int i = 0; i < deletHealth; i++)
            {
                DestroyHeart(_herts[_herts.Count - 1]);
            }
        }
    }

    private void DestroyHeart(Heart heart)
    {
        _herts.Remove(heart);
        heart.ToEmpty();
    }

    private void CreatHeart()
    {
        Heart newHeart = Instantiate(_heartTemplate, transform);
        _herts.Add(newHeart.GetComponent<Heart>());
        newHeart.ToFill();
    }

}
