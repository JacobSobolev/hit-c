namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        private const float k_MinEnergy = 0;
        private readonly float r_MaxEnergy;
        private float m_CurrentEnergy;

        public EnergySource(float i_MaxEnergy)
        {
            r_MaxEnergy = i_MaxEnergy;
            m_CurrentEnergy = k_MinEnergy;
        }

        public float MinEnergy
        {
            get { return k_MinEnergy; }
        }

        public float MaxEnergy
        {
            get { return r_MaxEnergy; }
        }

        public float CurrentEnergy
        {
            get { return m_CurrentEnergy; }
        }

        public float RemainingEnergyPercentage
        {
            get { return (m_CurrentEnergy / r_MaxEnergy) * 100; }
        }

        protected void AddEnergy(float i_EnergyToAdd)
        {
            if (i_EnergyToAdd >= k_MinEnergy)
            {
                if (i_EnergyToAdd + m_CurrentEnergy <= r_MaxEnergy)
                {
                    m_CurrentEnergy += i_EnergyToAdd;
                }
                else
                {
                    throw new ValueOutOfRangeException(k_MinEnergy, r_MaxEnergy - m_CurrentEnergy, "energey exceded the range valid is ");
                }
            }
            else
            {
                throw new ValueOutOfRangeException(k_MinEnergy, r_MaxEnergy - m_CurrentEnergy, "negative energey not in range valid is ");
            }
        }

        public override string ToString()
        {
            return string.Format("Remaning energy: {0}", RemainingEnergyPercentage);
        }
    }
}
