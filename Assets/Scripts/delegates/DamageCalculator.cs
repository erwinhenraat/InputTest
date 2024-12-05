public class DamageCalculator
{
    public delegate float DamageCalculation(float baseDamage, float armor, float multiplier);
    private static DamageCalculation currentCalculation;

    public static void SetDamageCalculation(DamageCalculation calculation)
    {
        currentCalculation = calculation;
    }
    public static float CalculateDamage(float baseDamage, float armor, float multiplier)
    {        
        //Invoke could return null so cast it to 0; 
        return (float)currentCalculation?.Invoke(baseDamage, armor, multiplier);           
    }
    public static float SwordCalculation(float baseDamage, float armor, float multiplier)
    {

        return (baseDamage - armor) * multiplier;
    }

    public static float HammerCalculation(float baseDamage, float armor, float multiplier)
    {
        return (baseDamage - (armor * 0.8f)) * multiplier; 
    }

    public static float SpearCalculation(float baseDamage, float armor, float multiplier)
    {
        return baseDamage * multiplier;
    }

}
public enum WeaponType
{
    Sword,
    Hammer,
    Spear
}