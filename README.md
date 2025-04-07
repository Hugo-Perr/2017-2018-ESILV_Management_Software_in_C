#   Zombillenium Park Management System

##   Project Overview

This repository contains a .net 4.6 project from my Oriented Object Programming in C and C# course at my engineering school ([ESILV](https://www.esilv.fr)). 
Its is a park management software for an amusement park, handling personnel allocation and attraction operations using class hierarchies for structured data, CSV parsing for dynamic updates, and an optimized staff allocation system based on a “cagnotte” mechanism. 
The graphical user interface (GUI) provides an interactive way to monitor attraction status, track maintenance, and manage staff assignments in real time, ensuring seamless park operations.
This project have been developed in Visual Studio.

##   Project Goals

The primary goals of this project are to:

* Develop a system to manage park personnel (monsters and sorcerers) and their assignments.
* Manage information about the park's attractions (RollerCoasters, Spectacles, Dark Rides, and shops).
* Provide functionalities to track attraction status (open/closed, maintenance) and personnel information (assignments, skills, etc.).
* Optimize personnel allocation and minimize attraction downtime.

##   System Features

The software should include the following features:

* **Data Input:** Read personnel and attraction data from a CSV file ("listing.csv") and add them to the system.
* **Data Management:**
    * Add new attractions and personnel.
    * Modify personnel and attraction information (e.g., job changes, maintenance schedules).
* **Data Retrieval:**
    * Retrieve lists of personnel or attractions based on specified criteria (e.g., all vampires, attractions under maintenance).
    * Output data to the console or CSV files.
* **Sorting:** Sort personnel or attractions based on given parameters (e.g., zombies by "cagnotte", demons by "force").
* **"Cagnotte" Management:**
    * Adjust monster "cagnotte" values (increase or decrease).
    * Implement automatic personnel actions based on "cagnotte" values:
        * Monsters with a "cagnotte" below 50 are assigned to a "barbe à papa" stand.
        * Zombies and demons with a "cagnotte" above 500 gain the temporary ability to "disappear" and are assigned to scare visitors in the park (unless staff is needed elsewhere).
* **User Interface:** A graphical user interface (GUI) to input new personnel information.

##   Data Model

The system manages data related to:

* **Personnel:**
    * Each member has a 5-digit ID, name, gender, and possibly a job title (e.g., union representative, intern, manager).
    * **Sorcerers:** Have a tattoo indicating their grade (novice/mega/giga/strata) and a list of powers.
    * **Monsters:** Assigned to attractions (unless in a full-time role), have a "cagnotte" for points, which influences their assignments and abilities.
        * **Demons:** Have a "force" rating (1-10).
        * **Zombies:** Have a color (blueish or grayish) and a decomposition level (1-10, skeletons have a decomposition level of 10).
        * **Werewolves:** Have a cruelty index (0-4).
        * **Vampires:** Have a luminosity index (0-3).
        * **Ghosts:** Their invisibility may be required for specific tasks.
* **Attractions:**
    * Each attraction has a 3-digit ID and a name, and status (open/closed), and maintenance details (duration).
    * Require a minimum number of monsters to operate, possibly with specific characteristics or types.
    * **RollerCoasters:** Have a category (seated/inverted/bobsleigh), minimum height, and age requirements.
    * **Spectacles:** Occur in a specific venue (e.g., Nergal, Leviathan), have a capacity, and show times (4-8 times daily).
    * **Dark Rides:** Have a ride duration and are either vehicle-based or walk-through.
    * **Shops:** Sell souvenirs, food, or drinks.

##   Implementation Details

* The core logic of the system is managed by an `Administration` class.
* The project involves reading and writing data to CSV files.
* The final submission includes a compiled solution, CSV data files, and a report.
* The project is developed in stages, with multiple deadlines and evaluations.

##   Evaluation

The project is evaluated based on:

* Code functionality and correctness.
* Code quality and organization.
* The design and implementation of the GUI.
* Project reports and documentation.
* Oral presentations and demonstrations.

##   Assignements

* [Rendu_PFR1_rapport.pdf](https://github.com/Hugo-Perr/2017-2018-ESILV_Management_Software_in_C/blob/master/Rendu_PFR1_rapport.pdf): Data Structure

