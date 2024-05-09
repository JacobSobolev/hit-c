namespace Ex03.GarageLogic
{
    public class ElectricSource : EnergySource
    {
        public ElectricSource(float i_MaxBatteryTime) : base(i_MaxBatteryTime)
        {
        }

        public void AddTimeToBattery(float i_TimeToAdd)
        {
            AddEnergy(i_TimeToAdd);
        }

        public override string ToString()
        {
            return string.Format("Electric Source - {0}", base.ToString());
        }
    }
}
