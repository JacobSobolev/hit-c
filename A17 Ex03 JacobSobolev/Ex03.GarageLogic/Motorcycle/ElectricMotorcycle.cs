namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        private const int k_MinEngineCapacity = 0;
        private const int k_MaxEngineCapacity = 1000;
        private eMotorcycleLicenseType m_MotorcycleLicenseType;
        private int m_EngineCapacity;

        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure, float i_MaxBatteryTime, eMotorcycleLicenseType i_MotorcycleLicenseType, int i_EngineCapacity) : base(i_ModelName, i_LicenseNumber, i_NumOfWheels, i_WheelManufacturerName, i_CurrentAirPressure, i_MaxAirPressure, i_MaxBatteryTime)
        {
            m_MotorcycleLicenseType = i_MotorcycleLicenseType;

            if (i_EngineCapacity >= k_MinEngineCapacity && i_EngineCapacity <= k_MaxEngineCapacity)
            {
                m_EngineCapacity = i_EngineCapacity;
            }
            else
            {
                throw new ValueOutOfRangeException(k_MinEngineCapacity, k_MaxEngineCapacity, "engine capacity not in range valid is ");
            }
        }

        public eMotorcycleLicenseType LicenseType
        {
            get { return m_MotorcycleLicenseType; }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
        }

        public override string ToString()
        {
            return string.Format(
@"
{0}
License Type: {1}
Engine Capacity: {2}
", base.ToString(), m_MotorcycleLicenseType.ToString(), m_EngineCapacity.ToString());
        }
    }
}
