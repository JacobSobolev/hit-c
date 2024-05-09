namespace Ex03.GarageLogic
{
    public abstract class FuelTruck : FuelVehicle
    {
        private const float k_MinCarryWeight = 0;
        private const float k_MaxCarryWeight = 5000;
        private readonly float m_CurrentMaxCarryWeight;
        private bool m_CarryingDangerousMaterials;

        public FuelTruck(string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure, eFuelType i_FuelType, float i_MaxFuelAmount, bool i_CarryingDangerousMaterials, float i_CurrentMaxCarryWeight) : base(i_ModelName, i_LicenseNumber, i_NumOfWheels, i_WheelManufacturerName, i_CurrentAirPressure, i_MaxAirPressure, i_FuelType, i_MaxFuelAmount)
        {
            m_CarryingDangerousMaterials = i_CarryingDangerousMaterials;
            m_CurrentMaxCarryWeight = i_CurrentMaxCarryWeight;
        }

        public static float MinCarryWeight
        {
            get { return k_MinCarryWeight; }
        }

        public static float MaxCarryWeight
        {
            get { return k_MaxCarryWeight; }
        }

        public bool IsCarryingDangerousMaterials
        {
            get { return IsCarryingDangerousMaterials; }
            set { m_CarryingDangerousMaterials = value; }
        }

        public float CurrentMaxCarryWeight
        {
            get { return m_CurrentMaxCarryWeight; }
        }

        public override string ToString()
        {
            return string.Format(
@"
{0}
Contains Dangerous Materials: {1}
Max Carry Weight: {2}
", base.ToString(), m_CarryingDangerousMaterials.ToString(), m_CurrentMaxCarryWeight.ToString());
        }
    }
}
