namespace Ex03.GarageLogic
{
    public class FuelCar : FuelVehicle
    {
        private const int k_MinNumberOfDoors = 2;
        private const int k_MaxNumberOfDoors = 5;
        private readonly int m_NumberOfDoors;
        private eCarColor m_CarColor;

        public FuelCar(string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure, eFuelType i_FuelType, float i_MaxFuelAmount, eCarColor i_CarColor, int i_NumberOfDoors) : base(i_ModelName, i_LicenseNumber, i_NumOfWheels, i_WheelManufacturerName, i_CurrentAirPressure, i_MaxAirPressure, i_FuelType, i_MaxFuelAmount)
        {
            m_CarColor = i_CarColor;

            if (i_NumberOfDoors >= k_MinNumberOfDoors && i_NumberOfDoors <= k_MaxNumberOfDoors)
            {
                m_NumberOfDoors = i_NumberOfDoors;
            }
            else
            {
                throw new ValueOutOfRangeException(k_MinNumberOfDoors, k_MaxNumberOfDoors, "number of doors not in range valid is ");
            }
        }

        public static int MinNumberOfDoors
        {
            get { return k_MinNumberOfDoors; }
        }

        public static int MaxNumberOfDoors
        {
            get { return k_MaxNumberOfDoors; }
        }

        public eCarColor CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public int NumberOfDoors
        {
            get { return m_NumberOfDoors; }
        }

        public override string ToString()
        {
            return string.Format(
@"
{0}
Car Color: {1}
Number Of Doors: {2}
", base.ToString(), m_CarColor.ToString(), NumberOfDoors.ToString());
        }
    }
}
