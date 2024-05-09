namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private readonly Vehicle r_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eGarageVehicleStatus m_VehicleStatus;

        public VehicleInGarage(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhone;
            m_VehicleStatus = eGarageVehicleStatus.InRepair;
            r_Vehicle = i_Vehicle;
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
            set { m_OwnerPhoneNumber = value; }
        }

        public eGarageVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public Vehicle Vehicle
        {
            get { return r_Vehicle; }
        }

        public override string ToString()
        {
            return string.Format(
@"
Owner Name: {0} 
Owner Phone: {1}
Vehicle Status: {2} 
{3}",
m_OwnerName, 
m_OwnerPhoneNumber, 
m_VehicleStatus.ToString(), 
r_Vehicle.ToString());
        }
    }
}
