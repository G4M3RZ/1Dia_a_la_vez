using System.Collections.Generic;
using UnityEngine;

public class Cloth_Reputation : MonoBehaviour
{
    public StressBar _bar;
    public List<float> _clothDamage;

    private void Start()
    {
        int cloth = PlayerPrefs.GetInt("Cloth");
        
        if(_clothDamage[cloth] != 0)
        {
            Color damage = (_clothDamage[cloth] > 0) ? Color.green : Color.red;
            _bar.SetStressBar(_clothDamage[cloth], damage);
        }
    }
}