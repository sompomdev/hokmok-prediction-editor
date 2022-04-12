
public class SMPManaVariant
{
    private static SMPManaVariant instance;

    public double manaRateFromSupports;
    public double numberOfMonsterKilledPerMinute;

    public static SMPManaVariant Instance ()
    {
        if (instance == null)
        {
            instance = new SMPManaVariant();
            instance.Initialize();
        }

        return instance;
    }
    private void Initialize ()
    {
        
    }
}
