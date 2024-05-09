using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private GarageManager m_GarageManager;

        public GarageUI()
        {
            m_GarageManager = new GarageManager();
        }

        public void RunGarageUI()
        {
            eUserMenuSelection userValidMenuSelection = eUserMenuSelection.AddVehicleToGarage;
            printWellcom();

            do
            {
                Console.WriteLine();
                printEnumType<eUserMenuSelection>();
                userValidMenuSelection = getUserInputBasedOnEnum<eUserMenuSelection>();
                if (userValidMenuSelection != eUserMenuSelection.Exit)
                {
                    preformAction(userValidMenuSelection);
                }
            }
            while (userValidMenuSelection != eUserMenuSelection.Exit);

            exitApplication();
        }

        private void printWellcom()
        {
            Console.WriteLine(
 @"
**            Welcome to Garage              **
  ===========================================
** Press the number of the requested action  **
  ===========================================
");
        }

        private void exitApplication()
        {
            Console.WriteLine("Bye Bye...");
            Console.WriteLine("press and key to countine...");
            Console.ReadKey();
        }

        private void preformAction(eUserMenuSelection i_ValidUserInput)
        {
            switch (i_ValidUserInput)
            {
                case eUserMenuSelection.AddVehicleToGarage:
                    addVehicleUI();
                    break;

                case eUserMenuSelection.ShowListOfAllOrFilteredLicenseNumbers:
                    showListOfAllLicenseNumbersByStatusUI();
                    break;

                case eUserMenuSelection.ChangeVehicleStatus:
                    changeVehicleStatusUI();
                    break;

                case eUserMenuSelection.FillAirPressureUntilMax:
                    fillAirPressureUntilMaxUI();
                    break;

                case eUserMenuSelection.FillFuelToVehicle:
                    fillFuelToVehicleUI();
                    break;

                case eUserMenuSelection.FillElectricityToVehicle:
                    fillElectricityToVehicleUI();
                    break;
                case eUserMenuSelection.ShowVehicleFullInfo:
                    showVehicleFullInfoUI();
                    break;
            }
        }

        private void addVehicleUI()
        {
            string licenseNumber = getUserInputString("Please enter license number");
            VehicleInGarage vehicleInGarage = m_GarageManager.VehicleExists(licenseNumber);
            if (vehicleInGarage != null)
            {
                Console.WriteLine("Vehicle Exists");
                vehicleInGarage.VehicleStatus = eGarageVehicleStatus.InRepair;
                Console.WriteLine("Changed status to {0}", vehicleInGarage.VehicleStatus.ToString());
            }
            else
            {
                string ownerName = getUserInputString("Please enter owner`s name");
                string ownerPhoneNumber = getUserInputString("Please enter owner`s phone number");
                printEnumType<eGarageVehicleTypes>();
                eGarageVehicleTypes vehicleType = getUserInputBasedOnEnum<eGarageVehicleTypes>();
                string modelName = getUserInputString("Please enter model name ");
                string wheelManufacer = getUserInputString("Enter Wheel Manufacter");
                Vehicle vehicleToGarage = null;

                if (vehicleType == eGarageVehicleTypes.FuelMotorCycle || vehicleType == eGarageVehicleTypes.ElectricMotorCycle)
                {
                    printEnumType<eMotorcycleLicenseType>();
                    eMotorcycleLicenseType motorCycleLisenseType = getUserInputBasedOnEnum<eMotorcycleLicenseType>();
                    int motorCycleEngineCapacity = getUserInputInRangeInt(FuelMotorcycle.MinEngineCapacity, FuelMotorcycle.MaxEngineCapacity, "Enter Engine Capacity");

                    if (vehicleType == eGarageVehicleTypes.FuelMotorCycle)
                    {
                        float currentAirPresure = getUserInputInRangeFloat(Wheel.MinAirPressure, GarageFuelMotorcycle.MaxWheelAirPressure, "Enter Wheel Air Pressure");
                        vehicleToGarage = new GarageFuelMotorcycle(modelName, licenseNumber, wheelManufacer, currentAirPresure, motorCycleLisenseType, motorCycleEngineCapacity);
                    }
                    else
                    {
                        float currentAirPresure = getUserInputInRangeFloat(Wheel.MinAirPressure, GarageElectricMotocycle.MaxWheelAirPressure, "Enter Wheel Air Pressure");
                        vehicleToGarage = new GarageElectricMotocycle(modelName, licenseNumber, wheelManufacer, currentAirPresure, motorCycleLisenseType, motorCycleEngineCapacity);
                    }
                }
                else if (vehicleType == eGarageVehicleTypes.FuelCar || vehicleType == eGarageVehicleTypes.ElectricCar)
                {
                    printEnumType<eCarColor>();
                    eCarColor carColor = getUserInputBasedOnEnum<eCarColor>();
                    
                    if (vehicleType == eGarageVehicleTypes.FuelCar)
                    {
                        int numberOfDoors = getUserInputInRangeInt(FuelCar.MinNumberOfDoors, FuelCar.MaxNumberOfDoors, "Enter number of doors");
                        float currentAirPresure = getUserInputInRangeFloat(Wheel.MinAirPressure, GarageFuelCar.MaxWheelAirPressure, "Enter Wheel Air Pressure");
                        vehicleToGarage = new GarageFuelCar(modelName, licenseNumber, wheelManufacer, currentAirPresure, carColor, numberOfDoors);
                    }
                    else
                    {
                        int numberOfDoors = getUserInputInRangeInt(ElectricCar.MinNumberOfDoors, ElectricCar.MaxNumberOfDoors, "Enter number of doors");
                        float currentAirPresure = getUserInputInRangeFloat(Wheel.MinAirPressure, GarageElectricCar.MaxWheelAirPressure, "Enter Wheel Air Pressure");
                        vehicleToGarage = new GarageElectricCar(modelName, licenseNumber, wheelManufacer, currentAirPresure, carColor, numberOfDoors);
                    }
                }
                else if (vehicleType == eGarageVehicleTypes.FuelTruk)
                {
                    Console.WriteLine("Is carrying dangerous materials ?");
                    printEnumType<eUserBooleanSelection>();
                    eUserBooleanSelection userBooleanSelection = getUserInputBasedOnEnum<eUserBooleanSelection>();
                    bool carryingDangerousMaterials = userBooleanSelection == eUserBooleanSelection.Yes ? true : false;
                    float maxCarryWeight = getUserInputInRangeFloat(FuelTruck.MinCarryWeight, FuelTruck.MaxCarryWeight, "Enter Max carry weight");
                    float currentAirPresure = getUserInputInRangeFloat(Wheel.MinAirPressure, GarageFuelTruck.MaxWheelAirPressure, "Enter Wheel Air Pressure");
                    vehicleToGarage = new GarageFuelTruck(modelName, licenseNumber, wheelManufacer, currentAirPresure, carryingDangerousMaterials, maxCarryWeight);
                }

                m_GarageManager.AddVehicle(new VehicleInGarage(ownerName, ownerPhoneNumber, vehicleToGarage));
                Console.WriteLine("Vehicle was added");
            }
        }

        private void printEnumType<T>()
        {
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                Console.WriteLine("{0} - {1}", (int)value, value.ToString());
            }
        }

        private T getUserInputBasedOnEnum<T>()
        {
            string userInput = null;
            bool userInputValid = false;
            int menuIndex = -1;

            do
            {
                try
                {
                    userInput = Console.ReadLine();
                    menuIndex = int.Parse(userInput);
                    if (!Enum.IsDefined(typeof(T), menuIndex))
                    {
                        throw new ArgumentException("Invalid Menu Selection");
                    }

                    userInputValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (!userInputValid);

            return (T)(object)menuIndex;
        }

        private int getUserInputInRangeInt(int i_minValue, int i_MaxValue, string i_Message)
        {
            bool validUserInput = false;
            int returnValue = -1;

            do
            {
                try
                {
                    Console.WriteLine(i_Message);
                    returnValue = int.Parse(Console.ReadLine());

                    if (returnValue >= i_minValue && returnValue <= i_MaxValue)
                    {
                        validUserInput = true;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(i_minValue, i_MaxValue, "not in rage valid is ");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (!validUserInput);

            return returnValue;
        }

        private float getUserInputInRangeFloat(float i_minValue, float i_MaxValue, string i_Message)
        {
            bool validUserInput = false;
            float returnValue = -1;

            do
            {
                try
                {
                    Console.WriteLine(i_Message);
                    returnValue = float.Parse(Console.ReadLine());

                    if (returnValue >= i_minValue && returnValue <= i_MaxValue)
                    {
                        validUserInput = true;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(i_minValue, i_MaxValue, "not in rage valid is ");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (!validUserInput);

            return returnValue;
        }

        private string getUserInputString(string i_Message)
        {
            Console.WriteLine(i_Message);
            return Console.ReadLine();
        }
  
        private void showListOfAllLicenseNumbersByStatusUI()
        {
            Console.WriteLine("Do you want to filter by status? ");
            printEnumType<eUserBooleanSelection>();
            eUserBooleanSelection userBooleanSelection = getUserInputBasedOnEnum<eUserBooleanSelection>();
            bool toFilter = userBooleanSelection == eUserBooleanSelection.Yes ? true : false;
            List<VehicleInGarage> vehiclesInGargeToShow = null;
            int index = 1;

            if (toFilter)
            {
                printEnumType<eGarageVehicleStatus>();
                eGarageVehicleStatus vehicleStatus = getUserInputBasedOnEnum<eGarageVehicleStatus>();
                vehiclesInGargeToShow = m_GarageManager.GetVehiclesByStatus(vehicleStatus);
            }
            else
            {
                vehiclesInGargeToShow = m_GarageManager.VehicleInGarageVec;
            }

            if (vehiclesInGargeToShow != null && vehiclesInGargeToShow.Count != 0)
            {
                Console.WriteLine();

                foreach (VehicleInGarage vehicle in vehiclesInGargeToShow)
                {
                    Console.WriteLine("{0} - {1}", index, vehicle.Vehicle.LicenseNumber);
                    index++;
                }
            }
            else
            {
                Console.WriteLine("no vehicles found");
            }
        }

        private void changeVehicleStatusUI()
        {
            VehicleInGarage vehicleInGarage = getfromUserlicenseNumber();

            if (vehicleInGarage != null)
            {
                Console.WriteLine("Please enter the new status");
                printEnumType<eGarageVehicleStatus>();
                eGarageVehicleStatus vehicleNewStatus = getUserInputBasedOnEnum<eGarageVehicleStatus>();
                if (m_GarageManager.ChangeVehicleSatus(vehicleInGarage, vehicleNewStatus))
                {
                    Console.WriteLine("Status changed");
                }
            }
        }

        private void fillAirPressureUntilMaxUI()
        {
            VehicleInGarage vehicleInGarage = getfromUserlicenseNumber();

            if (vehicleInGarage != null)
            {
                if (m_GarageManager.FillAirToMaxInVehicleWheels(vehicleInGarage))
                {
                    Console.WriteLine("Air filled to max");
                }
            }
        }

        private void fillFuelToVehicleUI()
        {
            VehicleInGarage vehicleInGarage = getfromUserlicenseNumber();

            if (vehicleInGarage != null)
            {
                try
                {
                    Console.WriteLine("Enter fuel to add");
                    printEnumType<eFuelType>();
                    eFuelType fuelType = getUserInputBasedOnEnum<eFuelType>();
                    Console.WriteLine("Enter The Amout To add");
                    float fuelAmout = float.Parse(Console.ReadLine());
                    if (m_GarageManager.FillFuelToVehicle(vehicleInGarage, fuelType, fuelAmout))
                    {
                        Console.WriteLine("Fill fuel to the vehicle");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void fillElectricityToVehicleUI()
        {
            VehicleInGarage vehicleInGarage = getfromUserlicenseNumber();

            if (vehicleInGarage != null)
            {
                try
                {
                    Console.WriteLine("Enter The Time To add");
                    float timeToAdd = float.Parse(Console.ReadLine());
                    if (m_GarageManager.FillElectrictyToVehicle(vehicleInGarage, timeToAdd))
                    {
                        Console.WriteLine("Fill Electricity to the vehicle");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void showVehicleFullInfoUI()
        {
            VehicleInGarage vehicleInGarage = getfromUserlicenseNumber();
            string vehicleInfo = m_GarageManager.GetVehicleInfo(vehicleInGarage);

            if (vehicleInfo != null)
            {
                Console.WriteLine(vehicleInGarage.ToString());
            }
        }

        private VehicleInGarage getfromUserlicenseNumber()
        {
            string licenseNumber = getUserInputString("Please enter license number");
            VehicleInGarage vehicleInGarage = m_GarageManager.VehicleExists(licenseNumber);

            if (vehicleInGarage == null)
            {
                Console.WriteLine("Vehicle doens't Exists");
            }

            return vehicleInGarage;
        }
    }
}
