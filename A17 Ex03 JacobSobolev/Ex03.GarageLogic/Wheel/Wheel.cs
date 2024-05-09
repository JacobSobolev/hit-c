using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private const float k_MinAirPressure = 0;
        private readonly string r_ManufacturerName;
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            r_MaxAirPressure = i_MaxAirPressure;

            if (i_CurrentAirPressure >= k_MinAirPressure && i_CurrentAirPressure <= i_MaxAirPressure)
            {
                m_CurrentAirPressure = i_CurrentAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(k_MinAirPressure, r_MaxAirPressure, "air presure not in range valid is ");
            }
        }

        public static float MinAirPressure
        {
            get { return k_MinAirPressure; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        public void AddAir(float i_AirToAdd)
        {
            if (i_AirToAdd >= k_MinAirPressure )
            {
                if (i_AirToAdd <= r_MaxAirPressure)
                {
                    m_CurrentAirPressure += i_AirToAdd;
                }
                else
                {
                    throw new ValueOutOfRangeException(k_MinAirPressure, r_MaxAirPressure - m_CurrentAirPressure, "air presure not in range valid is ");
                }
            }
            else
            {
                throw new ValueOutOfRangeException(k_MinAirPressure, r_MaxAirPressure - m_CurrentAirPressure, "negative air presure not in range valid is ");
            }
        }

        public void AddAirUntilMax()
        {
            AddAir(r_MaxAirPressure - m_CurrentAirPressure);
        }

        public override string ToString()
        {
            return string.Format("Wheel - Manufacturer :{0}, Current Air Pressure:{1}", r_ManufacturerName, m_CurrentAirPressure);
        }
    }
}
