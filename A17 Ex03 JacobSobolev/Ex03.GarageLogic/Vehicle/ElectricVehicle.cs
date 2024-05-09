namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        public ElectricVehicle(string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure, float i_MaxBatteryTime) : base(i_ModelName, i_LicenseNumber, i_NumOfWheels, i_WheelManufacturerName, i_CurrentAirPressure, i_MaxAirPressure)
        {
            m_EnergySrouce = new ElectricSource(i_MaxBatteryTime);
        }

        public float BatteryTimeLeft
        {
            get { return m_EnergySrouce.CurrentEnergy; }
        }

        public float BatterMaxTime
        {
            get { return m_EnergySrouce.MaxEnergy; }
        }

        public void AddElectricity(float i_TimeToAdd)
        {
            (m_EnergySrouce as ElectricSource).AddTimeToBattery(i_TimeToAdd);
        }

        public override string ToString()
        {
            return string.Format(
@"
{0}
{1}
Battrey precentage :{2}%
", base.ToString(), (m_EnergySrouce as ElectricSource).ToString(), RemainingEnergyPercentage);
        }
    }
}
