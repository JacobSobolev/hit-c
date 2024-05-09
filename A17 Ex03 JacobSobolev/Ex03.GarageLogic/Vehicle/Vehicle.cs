using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private string m_LicenseNumber;
        private List<Wheel> m_WheelsCollection;
        protected EnergySource m_EnergySrouce;

        public Vehicle(string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            r_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_WheelsCollection = new List<Wheel>(i_NumOfWheels);

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_WheelsCollection.Add(new Wheel(i_WheelManufacturerName, i_CurrentAirPressure, i_MaxAirPressure));
            }
        }

        public string ModelName
        {
            get { return r_ModelName; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public float RemainingEnergyPercentage
        {
            get { return m_EnergySrouce.RemainingEnergyPercentage; }
        }

        public int NumOfWheels
        {
            get { return m_WheelsCollection.Count; }
        }

        public List<Wheel> WheelsCollection
        {
            get { return m_WheelsCollection; }
        }

        protected EnergySource EnergySrouce
        {
            get { return m_EnergySrouce; }
        }

        public void AddAirToWheels(float i_AirToAdd)
        {
            foreach (Wheel currentWheel in m_WheelsCollection)
            {
                currentWheel.AddAir(i_AirToAdd);
            }
        }

        public void AddAirToWheelsUntilMax()
        {
            foreach (Wheel currentWheel in m_WheelsCollection)
            {
                currentWheel.AddAirUntilMax();
            }
        }

        public override string ToString()
        {
            StringBuilder outputString = new StringBuilder();
            int wheelNumber = 1;
            outputString.AppendFormat(
@"Vehicle Type: {0}
License Number: {1}
Model Name: {2} 
", GetType().Name, m_LicenseNumber, r_ModelName);

            foreach (Wheel currentWheel in m_WheelsCollection)
            {
                outputString.AppendFormat(
@"Wheel Number {0}: {1}
", 
wheelNumber, 
currentWheel.ToString());
                wheelNumber++;
            }

            return outputString.ToString();
        }
    }
}