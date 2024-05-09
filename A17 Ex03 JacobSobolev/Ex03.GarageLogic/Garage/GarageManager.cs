using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private List<VehicleInGarage> m_VehicleInGarageVec;

        public GarageManager()
        {
            m_VehicleInGarageVec = new List<VehicleInGarage>();
        }

        public List<VehicleInGarage> VehicleInGarageVec
        {
            get { return m_VehicleInGarageVec; }
        }

        public VehicleInGarage VehicleExists(string i_LicenseNumber)
        {
            VehicleInGarage returnValue = null;
            foreach (VehicleInGarage vehicleInGarage in m_VehicleInGarageVec)
            {
                if (vehicleInGarage.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    returnValue = vehicleInGarage;
                    break;
                }
            }

            return returnValue;
        }

        public bool AddVehicle(VehicleInGarage i_VehicleToAdd)
        {
            bool vehicleAdded = false;
            VehicleInGarage vehicleInGarage = VehicleExists(i_VehicleToAdd.Vehicle.LicenseNumber);

            if (vehicleInGarage != null)
            {
                vehicleInGarage.VehicleStatus = eGarageVehicleStatus.InRepair;
            }
            else
            {
                m_VehicleInGarageVec.Add(i_VehicleToAdd);
                vehicleAdded = true;
            }

            return vehicleAdded;
        }

        public List<VehicleInGarage> GetVehiclesByStatus(eGarageVehicleStatus i_VehicleStatus)
        {
            List<VehicleInGarage> returnVehicleVec = null;

            foreach (VehicleInGarage vehicleInGarage in m_VehicleInGarageVec)
            {
                if (vehicleInGarage.VehicleStatus == i_VehicleStatus)
                {
                    if (returnVehicleVec == null)
                    {
                        returnVehicleVec = new List<VehicleInGarage>();
                    }

                    returnVehicleVec.Add(vehicleInGarage);
                }
             }

            return returnVehicleVec;
        }

        public bool ChangeVehicleSatus(VehicleInGarage i_VehicleInGarage, eGarageVehicleStatus i_VehicleStatus)
        {
            bool changedStatus = false;

            if (i_VehicleInGarage != null)
            {
                i_VehicleInGarage.VehicleStatus = i_VehicleStatus;
                changedStatus = true;
            }

            return changedStatus;
        }

        public bool FillAirToMaxInVehicleWheels(VehicleInGarage i_VehicleInGarage)
        {
            bool filledAir = false;

            if (i_VehicleInGarage != null)
            {
                i_VehicleInGarage.Vehicle.AddAirToWheelsUntilMax();
                filledAir = true;
            }

            return filledAir;
        }

        public bool FillFuelToVehicle(VehicleInGarage i_VehicleInGarage, eFuelType i_FuelType, float i_FuelAmountToAdd)
        {
            bool filledFuel = false;

            if (i_VehicleInGarage != null)
            {
                if (i_VehicleInGarage.Vehicle is FuelVehicle)
                {
                    (i_VehicleInGarage.Vehicle as FuelVehicle).AddFuel(i_FuelType, i_FuelAmountToAdd);
                }
                else
                {
                    throw new InvalidOperationException("The vehicle isn't fuel based");
                }

                filledFuel = true;
            }

            return filledFuel;
        }

        public bool FillElectrictyToVehicle(VehicleInGarage i_VehicleInGarage, float i_TimeToAdd)
        {
            bool filledElectricity = false;

            if (i_VehicleInGarage != null)
            {
                if (i_VehicleInGarage.Vehicle is ElectricVehicle)
                {
                    (i_VehicleInGarage.Vehicle as ElectricVehicle).AddElectricity(i_TimeToAdd);
                }
                else
                {
                    throw new InvalidOperationException("The vehicle isn't Electricity based");
                }

                filledElectricity = true;
            }

            return filledElectricity;
        }

        public string GetVehicleInfo(VehicleInGarage i_vehicleInGarage)
        {
            string returnInfo = null;

            if (i_vehicleInGarage != null)
            {
                returnInfo = i_vehicleInGarage.ToString();
            }

            return returnInfo;
        }
    }
}
