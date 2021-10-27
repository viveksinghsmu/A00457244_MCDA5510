# Assignment #1
Name - **Vivek Singh** my student ID **A00457244**.

## About Assignment
Assignment is to read all csv files and create one file as output after validating First name should not be null and Postal code should not be null.

Main Class file which has main function **SimpleCSVParser**.

This will will read all csv files from **input_folder_path** and create 1 file as output in **output_folder_path + "output\output.csv"** along with log file in **output_folder_path+ "logs\logs.log"**.

While Reading csv files code will validate **First Name** and **Postal Code** and put all log of records discarded in log file.
Below is format of log file
**[file_name] has error [error name] at [line_number in csv]**
and in last of log file you will find summary

-Sample summary format
  -Started At 28-10-2021 03:09:39
  -Ended At 28-10-2021 03:10:14
  -Total Time 00:00:35
  -Total Records Loaded 226712
  -Total Records Discarded 56197
  -Total Records Discarded Because of First Name 50274 
  -Total Records Discarded Because of Postal Code 5923

