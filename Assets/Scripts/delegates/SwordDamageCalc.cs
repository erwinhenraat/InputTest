public class SwordDamageCalc : ICalculation
{
    public float Calculate(float baseDamage, float armor, float multiplier) { 
        return (baseDamage - armor) * multiplier;
    }
}
