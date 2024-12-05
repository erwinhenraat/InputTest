using TMPro;
using UnityEngine;

public class TestCalculations : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
        DamageCalculator.SetDamageCalculation(new SwordDamageCalc().Calculate);        
        Debug.Log("Damage is done :" + DamageCalculator.CalculateDamage(10, 8, 1.2f));
    }

}
