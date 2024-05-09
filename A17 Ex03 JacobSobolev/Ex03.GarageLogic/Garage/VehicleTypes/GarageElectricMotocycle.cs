namespace Ex03.GarageLogic
{
    public sealed class GarageElectricMotocycle : ElectricMotorcycle
    {
        private const int k_NumOfWheels = 2;
        private const float k_MaxWheelAirPressure = 31;
        private const float k_MaxBatteryTime = 2.5f;

        public GarageElectricMotocycle(string i_ModelName, string i_LicenseNumber, string i_WheelManufacturerName, float i_CurrentAirPressure, eMotorcycleLicenseType i_MotorcycleLicenseType, int i_EngineCapacity) : base(i_ModelName, i_LicenseNumber, k_NumOfWheels, i_WheelManufacturerName, i_CurrentAirPressure, k_MaxWheelAirPressure, k_MaxBatteryTime, i_MotorcycleLicenseType, i_EngineCapacity)
        {
        }

        public static float MaxWheelAirPressure
        {
            get { return k_MaxWheelAirPressure; }
        }
    }
}
