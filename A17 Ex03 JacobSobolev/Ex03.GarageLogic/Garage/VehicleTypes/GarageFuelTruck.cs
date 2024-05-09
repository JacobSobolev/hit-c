namespace Ex03.GarageLogic
{
    public sealed class GarageFuelTruck : FuelTruck
    {
        private const int k_NumOfWheels = 12;
        private const float k_MaxWheelAirPressure = 26;
        private const eFuelType k_FuelType = eFuelType.Octan96;
        private const float k_MaxFuelAmount = 150f;

        public GarageFuelTruck(string i_ModelName, string i_LicenseNumber, string i_WheelManufacturerName, float i_CurrentAirPressure, bool i_CarryingDangerousMaterials, float i_MaxCarryWeight) : base(i_ModelName, i_LicenseNumber, k_NumOfWheels, i_WheelManufacturerName, i_CurrentAirPressure, k_MaxWheelAirPressure, k_FuelType, k_MaxFuelAmount, i_CarryingDangerousMaterials, i_MaxCarryWeight)
        {
        }

        public static float MaxWheelAirPressure
        {
            get { return k_MaxWheelAirPressure; }
        }
    }
}
