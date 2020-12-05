using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperRepo;
using DevTeamRepo;

namespace Komodo_Insurance_Console
{
    class ProgramUI
    {
        private DevRepo _programmerRepo = new DevRepo();
        private DevTeamRep _teamRepo = new DevTeamRep();

        // Method that runs/starts the application
        public void Run()
        {
            SeedDeveloperList();
            SeedDevTeamList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                // Display our options to the user
                Console.WriteLine("Select a menu option:\n" +

                "1. Create developer\n" +
                "2. View all developers\n" +
                "3. View developer by Developer ID\n" +
                "4. Needs a PluralSight license\n" +
                "5. Update existing developer\n" +
                "6. Delete existing developer\n" +
                "7. Create developemnt team\n" +
                "8. View all teams\n" +
                "9. View devlopment team by TeamID\n" +
                "10. Add developer to dev team\n" +
                "11. Remove developer from dev team\n" +
                "12. Update existing team\n" +
                "13. Delete existing team\n" +
                "14. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // Create new developer
                        CreateNewDeveloper();
                        break;
                    case "2":
                        // View all developers
                        DisplayAllDevelopers();
                        break;
                    case "3":
                        // View developer by id
                        DisplayIndividualDeveloperByID();
                        break;
                    case "4":
                        // Needs a plural sight license
                        PluralSightLicense();
                        break;
                    case "5":
                        // Update existing developer
                        UpdateExistingDeveloper();
                        break;
                    case "6":
                        // Delete existing developer
                        DeleteExistingDeveloper();
                        break;
                    case "7":
                        // Create development team
                        CreateDevelopmentTeam();
                        break;
                    case "8":
                        // View all teams
                        ViewAllDevTeams();
                        break;
                    case "9":
                        // View development team by TeamID
                        ViewDevTeamByID();
                        break;
                    case "10":
                        // Add developer to dev team
                        AddDeveloperToTeam();
                        break;
                    case "11":
                        // Remove developer from dev team
                        RemoveDeveloperFromTeam();
                        break;
                    case "12":
                        // Update existing team
                        UpdateExistingTeam();
                        break;
                    case "13":
                        // Delete existing team
                        DeleteExistingTeam();
                        break;
                    case "14":
                        // Exit
                        keepRunning = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Create new developer
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            // ID Number
            Console.WriteLine("Enter the ID Number of the developer.");
            string idNumber = Console.ReadLine();
            newDeveloper.IDNumber = int.Parse(idNumber);

            // First Name
            Console.WriteLine("Enter the developer's first name.");
            newDeveloper.DeveloperFirstName = Console.ReadLine();

            // Last Name
            Console.WriteLine("Enter the developer's last name.");
            newDeveloper.DeveloperLastName = Console.ReadLine();

            // PluralSight
            Console.WriteLine("Is this developer PluralSight licensed? (y/n)");
            string PluralSight = Console.ReadLine().ToLower();

            if (PluralSight == "y")
            {
                newDeveloper.PluralSight = true;
            }
            else
            {
                newDeveloper.PluralSight = false;
            }

            _programmerRepo.AddDeveloperToList(newDeveloper);
        }

        // View all developers
        private void DisplayAllDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _programmerRepo.GetDeveloperList();

            foreach (Developer programmer in listOfDevelopers)
            {
                Console.WriteLine($"IDNumber:{programmer.IDNumber}\n" +
                    $"Developer First Name: {programmer.DeveloperFirstName}\n" +
                    $"Developer Last Name: {programmer.DeveloperLastName}\n" +
                    $"PluralSight: {programmer.PluralSight}");
            }
        }

        // View individual developer by ID
        private void DisplayIndividualDeveloperByID()
        {
            Developer newDeveloper = new Developer();

            Console.Clear();
            // Prompt the user to give me a DeveloperID
            Console.WriteLine("Enter the DeveloperID of the developer you'd like to see:");

            // Get the user's input
            string newDevIDNumber = Console.ReadLine();
            newDeveloper.IDNumber = int.Parse(newDevIDNumber);

            // Find the developer by that DeveloperID
            Developer programmer = _programmerRepo.GetDeveloperByIDNumber(newDeveloper.IDNumber);

            // Display said DeveloperID if it isn't null
            if (programmer != null)
            {
                Console.WriteLine($"Developer ID: {programmer.IDNumber}\n" +
                    $"First Name: {programmer.DeveloperFirstName}\n" +
                    $"Last Name: {programmer.DeveloperLastName}\n" +
                    $"PluralSight: {programmer.PluralSight}");
            }
            else
            {
                Console.WriteLine("no developer by that id.");
            }

        }

        // Needs a PluralSight license
        private void PluralSightLicense()
        {

        }

        // Update existing developer
        private void UpdateExistingDeveloper()
        {
            // Display all developers
            DisplayAllDevelopers();

            // Ask for the DeveloperID of the developer to update
            Console.WriteLine("Enter the DeveloperID of the developer you'd like to update.");

            // Get that developer
            string oldDevIDNumber = Console.ReadLine();
            Developer newDeveloper = new Developer();
            newDeveloper.IDNumber = int.Parse(oldDevIDNumber);

            /*int idNumber, Developer newProgrammer*/

            // We will build a new object
            /*Developer newDeveloper = new Developer();*/

            // ID Number
            Console.WriteLine("Enter the ID Number of the developer.");
            string idNumber = Console.ReadLine();
            newDeveloper.IDNumber = int.Parse(idNumber);

            // First Name
            Console.WriteLine("Enter the developer's first name.");
            newDeveloper.DeveloperFirstName = Console.ReadLine();

            // Last Name
            Console.WriteLine("Enter the developer's last name.");
            newDeveloper.DeveloperLastName = Console.ReadLine();

            // PluralSight
            Console.WriteLine("Is this developer PluralSight licensed? (y/n)");
            string PluralSight = Console.ReadLine().ToLower();

            if (PluralSight == "y")
            {
                newDeveloper.PluralSight = true;
            }
            else
            {
                newDeveloper.PluralSight = false;
            }

            // Verify the update worked
            bool wasUpdated = _programmerRepo.UpdateExistingDeveloper(newDeveloper.IDNumber, newDeveloper);

            if (wasUpdated)
            {
                Console.WriteLine("Developer successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update develper.");
            }
        }


        // Delete existing developer
        private void DeleteExistingDeveloper()
        {
            DisplayAllDevelopers();

            // Get the Developer ID of the developer they want to remove
            Console.WriteLine("\nEnter the Developer ID of the developer you'd like to remove:");

            string devIDNumber = Console.ReadLine();
            Developer newDeveloper = new Developer();
            newDeveloper.IDNumber = int.Parse(devIDNumber);

            // Call the delete method
            bool wasDeleted = _programmerRepo.RemoveDeveloperFromList(newDeveloper.IDNumber);

            // If the content was deleted, say so
            // Otherwise state it could not be deleted
            if (wasDeleted)
            {
                Console.WriteLine("The developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The developer could not be deleted.");
            }

            DevRepo _repo = new DevRepo();

           
        }

        // See method
        private void SeedDeveloperList()
        {
            Developer programmer = new Developer("Eric", "Bella", 365, true);
            Developer programmer2 = new Developer("Tracy", "Smothers", 456, false);

            _programmerRepo.AddDeveloperToList(programmer);
            _programmerRepo.AddDeveloperToList(programmer2);
        }

        private void SeedDevTeamList()
        {
            DevTeam team1 = new DevTeam("Colts", 1);
            DevTeam team2 = new DevTeam("Saints", 5);

            _teamRepo.AddDevTeamToList(team1);
            _teamRepo.AddDevTeamToList(team2);
        }

        // Create development team
        private void CreateDevelopmentTeam()
        {
            Console.Clear();
            DevTeam newTeam = new DevTeam();

            // ID Number
            Console.WriteLine("Enter the ID Number of the team.");
            string devIDNumber = Console.ReadLine();
            newTeam.TeamID = int.Parse(devIDNumber);

            // Team Name
            Console.WriteLine("Enter the team name.");
            newTeam.TeamName = Console.ReadLine();

            // Team of Developers
            //List<Developer> teamMembers = new List<Developer>();
            //newTeam.ListOfDevelopers = teamMembers;

            _teamRepo.AddDevTeamToList(newTeam);
        }

        //View all teams
        private void ViewAllDevTeams()
        {
            Console.Clear();
            List<DevTeam> ListOfDevTeams = _teamRepo.GetDevTeamList();

            //List<Developer> teamMembers = new List<Developer>();
            foreach (DevTeam team in ListOfDevTeams)
            {
                Console.WriteLine($"IDNumber:{team.TeamID}\n" +
                    $"Team Name: {team.TeamName}");

                if (team.ListOfDevelopers != null)
                {
                    foreach (Developer teamMember in team.ListOfDevelopers)
                    {

                        Console.WriteLine($"Team Member: {teamMember}");
                    }

                }
                else
                {
                    Console.WriteLine("No team members exist");
                }

            }
        }

        // View development team by TeamID
        private void ViewDevTeamByID()
        {
            Console.Clear();
            DevTeam newTeam = new DevTeam();

            // Prompt the user to give a Team ID
            Console.WriteLine("Enter the TeamID of the team you'd like to see.");

            // Get the user's input
            string newDevIDNumber = Console.ReadLine();
            newTeam.TeamID = int.Parse(newDevIDNumber);

            // Find the team by TeamID
            DevTeam team = _teamRepo.GetDevTeamByID(newTeam.TeamID);

            // Display team if TeamID isn't null
            if (team != null)
            {
                Console.WriteLine($"IDNumber:{team.TeamID}\n" +
                    $"Team Name: {team.TeamName}");

                if (team.ListOfDevelopers != null)
                {
                    foreach (Developer teamMember in team.ListOfDevelopers)
                    {

                        Console.WriteLine($"Team Member: {teamMember}");
                    }
                }
                else
                {
                    Console.WriteLine("No team members exist");
                }

            }
        }


        // Add developer to development team
        private void AddDeveloperToTeam()
        {
            Console.Clear();


            // Prompt the user to give a Team ID
            Console.WriteLine("Enter the TeamID of the team you'd like to add a developer to.");

            // Get the user's input
            string teamID = Console.ReadLine();
            int group = int.Parse(teamID);

            // Find the team by TeamID
            DevTeam team = _teamRepo.GetDevTeamByID(group);

            // Display team if TeamID isn't null
            if (team != null)
            {
                Console.WriteLine($"IDNumber:{team.TeamID}\n" +
                 $"Team Name: {team.TeamName}");


                if (team.ListOfDevelopers != null)
                {
                    foreach (Developer teamMember in team.ListOfDevelopers)
                    {

                        Console.WriteLine($"Team Member: {teamMember}");
                    }
                }
                else
                {
                    Console.WriteLine("No team members exist");
                }


                DisplayAllDevelopers();

                Console.WriteLine("Type in Developer ID of the developer you would like to add to the team.");
                string programmer = Console.ReadLine();
                int developerID = int.Parse(programmer);
                List<Developer> devs = _programmerRepo.GetDeveloperList();

                foreach (Developer contractor in devs)
                {
                    if (contractor.IDNumber == developerID)
                    {
                        _teamRepo.AddDeveloperToTeam(contractor, team);
                    }
                }
            }

        }      
                

        // Remove developer from development team
        private void RemoveDeveloperFromTeam()
        {
                Console.Clear();

                // Prompt the user to give a Team ID
                Console.WriteLine("Enter the TeamID of the team you'd like to remove a developer from.");

                // Get the user's input
                string teamID = Console.ReadLine();
                int group = int.Parse(teamID);

                // Find the team by TeamID
                DevTeam team = _teamRepo.GetDevTeamByID(group);

                // Display team if TeamID isn't null
                if (team != null)
                {
                    Console.WriteLine($"IDNumber:{team.TeamID}\n" +
                     $"Team Name: {team.TeamName}");


                    if (team.ListOfDevelopers != null)
                    {
                        foreach (Developer teamMember in team.ListOfDevelopers)
                        {

                            Console.WriteLine($"Team Member: {teamMember}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No team members exist");
                    }


                    DisplayAllDevelopers();

                    Console.WriteLine("Type in Developer ID of the developer you would like to remove from the team.");
                    string programmer = Console.ReadLine();
                    int developerID = int.Parse(programmer);
                    List<Developer> devs = _programmerRepo.GetDeveloperList();

                    foreach (Developer contractor in devs)
                    {
                        if (contractor.IDNumber == developerID)
                        {
                            _teamRepo.RemoveDeveloperFromTeam(contractor, team);
                        }
                    }
                }

            }


        // Update existing team
        private void UpdateExistingTeam()
        {
            // Display all teams
            ViewAllDevTeams();

            // Ask for the TeamID of the development team to update
            Console.WriteLine("Enter the TeamID of the development team you'd like to update:");

            // Get that TeamID
            string oldTeamID = Console.ReadLine();
            DevTeam newTeam = new DevTeam();
            newTeam.TeamID = int.Parse(oldTeamID);

            // ID Number
            Console.WriteLine("Enter the ID Number of the team.");
            string devIDNumber = Console.ReadLine();
            newTeam.TeamID = int.Parse(devIDNumber);

            // Team Name
            Console.WriteLine("Enter the team name.");
            newTeam.TeamName = Console.ReadLine();

            // Team of Developers
            List<Developer> teamMembers = new List<Developer>();
            newTeam.ListOfDevelopers = teamMembers;

            // Verify the update worked
            bool wasUpdated = _teamRepo.UpdateExistingDevTeam(newTeam.TeamID, newTeam);

            if (wasUpdated)
            {
                Console.WriteLine("Team sucessfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update content.");
            }
        }



        // Delete existing team
        private void DeleteExistingTeam()
        {
            Console.Clear();

            ViewAllDevTeams();

            // Get the Developer ID of the team they want to remove
            Console.WriteLine("\nEnter the TeamID of the team you'd like to remove");

            string devTeamIDNumber = Console.ReadLine();
            DevTeam newDevTeam = new DevTeam();
            newDevTeam.TeamID = int.Parse(devTeamIDNumber);

            // Call the delete method
            bool wasDeleted = _teamRepo.RemoveTeamFromList(newDevTeam.TeamID);

            // If the content was deleted, say so
            // Otherwise state it could not be deleted
            if (wasDeleted)
            {
                Console.WriteLine("The development team was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The development team could not be deleted.");
            }
        }
    }
}


