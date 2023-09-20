using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PrisonProjectFinal
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Warden> WardensList = new List<Warden>();
            List<Prisoner> PrisonersList = new List<Prisoner>();

            // Creating Ward A and assigning properties set out in instructions.
            Ward WardA = new Ward();
            WardA.WardName = "Ward A";
            WardA.CellNo = 30;
            WardA.CellCapacity = 2;

            // Doing the same for Ward B
            Ward WardB = new Ward();
            WardB.WardName = "Ward B";
            WardB.CellNo = 40;
            WardB.CellCapacity = 3;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Prisoner Menu");
                Console.WriteLine("2. Warden Menu");
                Console.WriteLine("3. Ward Menu");
                string opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("1. New Prisoner");
                        Console.WriteLine("2. View/Update Prisoner");
                        opt = Console.ReadLine();
                        switch (opt)
                        {
                            case "1":
                                Prisoner temp = new Prisoner();
                                temp.UpdateInfo();
                                PrisonersList.Add(temp);
                                break;
                            case "2":
                                Console.Clear();
                                for (int i = 0; i < PrisonersList.Count; i++)
                                {
                                    Console.WriteLine("{0}: {1}", i, PrisonersList[i].PrisonerNumber);
                                }
                                Console.Write("Option: ");
                                opt = Console.ReadLine();

                                Console.WriteLine("Update (u) or View (v)?");
                                string opt2 = Console.ReadLine();
                                if (opt2 == "u")
                                {
                                    PrisonersList[Int32.Parse(opt)].UpdateInfo();
                                }
                                else if (opt2=="v")
                                {
                                    PrisonersList[Int32.Parse(opt)].ViewInformation();
                                }
                                break;
                            default:
                                Console.WriteLine("Error");
                                Console.ReadLine();
                                break;
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("1. New Warden");
                        Console.WriteLine("2. View/Update Warden");
                        opt = Console.ReadLine();
                        switch (opt)
                        {
                            case "1":
                                Warden temp = new Warden();
                                temp.UpdateInfo();
                                WardensList.Add(temp);
                                break;
                            case "2":
                                Console.Clear();
                                for (int i = 0; i < WardensList.Count; i++)
                                {
                                    Console.WriteLine("{0}: {1}", i, WardensList[i].WardenNumber);
                                }
                                Console.Write("Option: ");
                                opt = Console.ReadLine();

                                Console.WriteLine("Update (u) or View (v)?");
                                string opt2 = Console.ReadLine();
                                if (opt2 == "u")
                                {
                                    WardensList[Int32.Parse(opt)].UpdateInfo();
                                }
                                else if (opt2 == "v")
                                {
                                    WardensList[Int32.Parse(opt)].ViewInformation();
                                }
                                break;
                            default:
                                Console.WriteLine("Error");
                                Console.ReadLine();
                                break;
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("1. Ward A");
                        Console.WriteLine("2. Ward B");
                        opt = Console.ReadLine();
                        switch (opt)
                        {
                            case "1":
                                WardA.ViewInformation();
                                Console.ReadLine();
                                break;
                            case "2":
                                WardB.ViewInformation();
                                Console.ReadLine();
                                break;
                            default:
                                Console.WriteLine("Please make a valid entry.");
                                Console.ReadLine();
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Please make sure you select from the list.");
                        Console.ReadLine();
                        break;
                }
               

            }
            

        }

        class Ward
        {
            // Cell information is public as they are assigned a value at the start of the code.
            public string WardName;
            public int CellNo;
            public int CellCapacity;

            public void ViewInformation()
            {
                Console.Clear();
                Console.WriteLine("Viewing information of {0}", WardName);
                Console.WriteLine("There are {0} Cells, each with a capacity of {1} prisoners.", CellNo, CellCapacity);
                Console.ReadLine();
            }

        }

        class Person
        {
            public string Name;
            public Ward AssignedWard;

            public void ViewInformation()
            {

            }
        }

        class Prisoner : Person
        {
            public string PrisonerNumber;
            public string CellNo;

            public void UpdateInfo()
            {
                Console.Clear();
                Console.Write("Prisoner Name: ");
                Name = Console.ReadLine();

                Console.Write("Prisoner Number: ");

                PrisonerNumber = Console.ReadLine();
                bool validationfail = false;
                for (int i = 0; i < PrisonerNumber.Length; i++)
                {
                    if ("1234567890".Contains(PrisonerNumber[i])) {
                        validationfail = false;
                    }
                    else
                    {
                        validationfail = true;
                    }
                }

                if (validationfail == true)
                {
                    Console.WriteLine("PrisonerNumber can only contain integers.");
                    Console.ReadLine();
                    UpdateInfo();
                    return;
                }

                Console.Write("CellNumber: ");
                CellNo= Console.ReadLine();

                for (int i = 0; i < CellNo.Length; i++)
                {
                    if ("1234567890".Contains(CellNo[i]))
                    {
                        validationfail = false;
                    }
                    else
                    {
                        validationfail = true;
                    }
                }

                if (validationfail == true)
                {
                    Console.WriteLine("CellNumber can only contain integers.");
                    Console.ReadLine();
                    UpdateInfo();
                    return;
                }

                Console.WriteLine("Successfully added information.");
                Console.ReadLine();

            }

            public void ViewInformation()
            {
                Console.Clear();
                Console.WriteLine("Prisoner Name: {0}", Name);
                Console.WriteLine("Prisoner No: {0}", PrisonerNumber);
                Console.WriteLine("Cell: {0}", CellNo);

                Console.WriteLine(); // Line Break

                Console.ReadLine();

            }

        }

        class Warden : Person
        {
            public string WardenNumber;
            public string Ward;

            public void UpdateInfo()
            {
                Console.Clear();
                Console.Write("Warden Name: ");
                Name = Console.ReadLine();

                Console.Write("Warden No: ");
                WardenNumber = Console.ReadLine();

                bool validationfail = false;
                for (int i = 0; i < WardenNumber.Length; i++)
                {
                    if ("1234567890".Contains(WardenNumber[i]))
                    {
                        validationfail = false;
                    }
                    else
                    {
                        validationfail = true;
                    }
                }

                if (validationfail == true)
                {
                    Console.WriteLine("WardenNumber can only contain integers.");
                    Console.ReadLine();
                    UpdateInfo();
                    return;
                }

                Console.WriteLine("Ward A or B?");
                string choice = Console.ReadLine();
                if (choice == "a" ^ choice=="A") {
                    Ward = "Ward A";
                }
                else if (choice == "a" ^ choice == "b")
                {
                    Ward = "Ward B";
                }
                else
                {
                    Console.WriteLine("Please make a valid selection");
                    UpdateInfo();
                    return;
                }

            }

            public void ViewInformation()
            {
                Console.Clear();
                Console.WriteLine("Warde Name: {0}", Name);
                Console.WriteLine("Warden No: {0}", WardenNumber);
                Console.WriteLine("Ward: {0}", Ward);

                Console.WriteLine(); // Line Break

                Console.ReadLine();
            }

        }

    }


}
