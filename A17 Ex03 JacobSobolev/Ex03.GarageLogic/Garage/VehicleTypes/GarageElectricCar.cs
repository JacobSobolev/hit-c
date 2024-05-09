namespace Ex03.GarageLogic
{
    public sealed class GarageElectricCar : ElectricCar
    {
        private const int k_NumOfWheels = 4;
        private const float k_MaxWheelAirPressure = 32;
        private const float k_MaxBatteryTime = 2.7f;

        public GarageElectricCar(string i_ModelName, string i_LicenseNumber, string i_WheelManufacturerName, float i_CurrentAirPressure, eCarColor i_CarColor, int i_NumberOfDoors) : base(i_ModelName, i_LicenseNumber, k_NumOfWheels, i_WheelManufacturerName, i_CurrentAirPressure, k_MaxWheelAirPressure, k_MaxBatteryTime, i_CarColor, i_NumberOfDoors)
        {
        }

        public static float MaxWheelAirPressure
        {
            get { return k_MaxWheelAirPressure; }
        }
    }
}
