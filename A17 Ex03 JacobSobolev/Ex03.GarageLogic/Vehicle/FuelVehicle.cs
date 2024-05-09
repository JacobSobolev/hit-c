namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {
        public FuelVehicle(string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure, eFuelType i_FuelType, float i_MaxFuelAmount) : base(i_ModelName, i_LicenseNumber, i_NumOfWheels, i_WheelManufacturerName, i_CurrentAirPressure, i_MaxAirPressure)
        {
            m_EnergySrouce = new FuelSource(i_FuelType, i_MaxFuelAmount);
        }

        public eFuelType FuelType
        {
            get { return (m_EnergySrouce as FuelSource).FuelType; }
        }

        public float CurrentFuelAmount
        {
            get { return m_EnergySrouce.CurrentEnergy; }
        }

        public float MaxFuelAmount
        {
            get { return m_EnergySrouce.MaxEnergy; }
        }

        public void AddFuel(eFuelType i_FuelType, float i_FuelToAddAmount)
        {
            (m_EnergySrouce as FuelSource).AddFuel(i_FuelType, i_FuelToAddAmount);
        }

        public override string ToString()
        {
            return string.Format(
@"
{0}
{1}
Fuel Precentage: {2}%
", base.ToString(), (m_EnergySrouce as FuelSource).ToString(), RemainingEnergyPercentage);
        }
    }
}
