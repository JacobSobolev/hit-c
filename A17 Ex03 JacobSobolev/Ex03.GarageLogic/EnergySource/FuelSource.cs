using System;

namespace Ex03.GarageLogic
{
    public class FuelSource : EnergySource
    {
        private readonly eFuelType m_FuelType;

        public FuelSource(eFuelType i_FuelType, float i_MaxFuelAmount) : base(i_MaxFuelAmount)
        {
            m_FuelType = i_FuelType;
        }
        
        public eFuelType FuelType
        {
            get { return m_FuelType; }
        }

        public void AddFuel(eFuelType i_FuelType, float i_FuelToAddAmount)
        {
            if (i_FuelType == FuelType)
            {
                AddEnergy(i_FuelToAddAmount);
            }
            else
            {
                throw new ArgumentException("The fuel type is invalid!");
            }
        }

        public override string ToString()
        {
            return string.Format("Fuel Source - Fuel Type: {0} ,{1}", m_FuelType.ToString(), base.ToString());
        }
    }
}
