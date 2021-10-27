using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Assignment1
{
    public class SimpleCSVParser
    {
        
        static string input_Folder_path = @"C:\Users\VIVEK\source\repos\MCDA5510_Assignments\Sample Data\Sample Data\"; // path to input folder where csv files are kept ending with /
        static string output_folder_path = @"C:\Users\VIVEK\source\repos\MCDA5510_Assignments\Assignment1\"; // path to output folder where output needs to be created ending with /
        static  int  Records_loaded = 0;
        static int Records_discarded_first_name = 0;
        static int Records_discarded_postal_Code = 0;

        static int  records_discarded = 0;
        static DateTime start_date ;
        static DateTime end_date ;
        public static void Main(String[] args)
        {
            if (input_Folder_path is null) // checking input folder path is blank or not 
            {
                Console.WriteLine("You did not supply a input folder path.");
                
            }
            if (output_folder_path is null) // checking output folder path is blank or not 
            {
                Console.WriteLine("You did not supply a output folder path.");
                
            }

            try
            {
                start_date = System.DateTime.Now; // starting time when code will start executing to share same detail in log
                StreamWriter write_output = new StreamWriter(output_folder_path +@"output\output.csv", false);
                write_output.WriteLine("First Name,Last Name,Street Number,Street,City,Province,Postal Code,Country,Phone Number,email Address,date");
                write_output.Close();

                StreamWriter write_log = new StreamWriter(output_folder_path + @"logs\logs.log", false);
                write_log.Close();
                SimpleCSVParser parser = new SimpleCSVParser();
                string[] files = Directory.GetFiles(input_Folder_path, "*.csv", System.IO.SearchOption.AllDirectories); // traverse through all directories to read csv files 
                foreach (string file in files)
                {
                    parser.parse(file); // calling parser.parse function to read csv files
                }
                end_date = System.DateTime.Now; // starting time when code will start executing to share same detail in log

                StreamWriter write_log1 = new StreamWriter(output_folder_path + @"logs\logs.log", true);
                write_log1.WriteLine("");
                write_log1.WriteLine(""); // printing details to log file
                write_log1.WriteLine("Started At " + start_date);  // printing details to log file
                write_log1.WriteLine("Ended At " + end_date);  // printing details to log file
                write_log1.WriteLine("Total Time " + DateTime.Parse(end_date.ToLongTimeString()).Subtract(DateTime.Parse(start_date.ToLongTimeString())));  // printing time taken to execute to log file

                write_log1.WriteLine("Total Records Loaded " + Records_loaded.ToString());
                write_log1.WriteLine("Total Records Discarded " + records_discarded.ToString());
                write_log1.WriteLine("Total Records Discarded Because of First Name " + Records_discarded_first_name.ToString());
                write_log1.WriteLine("Total Records Discarded Because of Postal Code " + Records_discarded_postal_Code.ToString());
                write_log1.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive specified in 'path' is invalid.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("'path' exceeds the maxium supported path length.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to create this file.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                Console.WriteLine("There is a sharing violation.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
            {
                Console.WriteLine("The file already exists.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }
        }


        public void parse(String fileName)
        {
            
                StreamWriter write_output = new StreamWriter(output_folder_path + @"output\output.csv", true);
            StreamWriter write_log = new StreamWriter(output_folder_path + @"logs\logs.log", true);

            try
            {
                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    int line_count = 0;
                    while (!parser.EndOfData)
                    {

                        line_count++;
                        string print_line = "";
                        //Process row
                        string[] fields = parser.ReadFields();
                        if (fields[0] != "First Name") // Checking is it header or not - if not header then reading fields
                        {

                            if (fields.Length == 0 || fields[0].Trim() == "")// checkng first name is not null
                            {
                                write_log.WriteLine(fileName.Replace(input_Folder_path, "") + " has error " + "First Name is Blank at " + line_count.ToString());
                                records_discarded++;
                                Records_discarded_first_name++;


                                continue;
                            }
                            else
                            { print_line = fields[0] + ","; }



                            if (fields.Length >= 2) // checking in case file has only column less than count >= 
                            {
                                print_line = print_line + fields[1] + ",";

                            }
                            else { print_line = print_line + ","; }

                            if (fields.Length >= 3) // checking in case file has only column less than count >= 
                            {
                                print_line = print_line + fields[2] + ",";

                            }
                            else { print_line = print_line + ","; }

                            if (fields.Length >= 4) // checking in case file has only column less than count >= 
                            {
                                print_line = print_line + "\"" + fields[3] + "\"" + ",";

                            }
                            else { print_line = print_line + ","; }

                            if (fields.Length >= 5) // checking in case file has only column less than count >= 
                            {
                                print_line = print_line + fields[4] + ",";

                            }
                            else { print_line = print_line + ","; }

                            if (fields.Length >= 6) // checking in case file has only column less than count >= 
                            {
                                print_line = print_line + fields[5] + ",";

                            }
                            else { print_line = print_line + ","; }

                            if (fields.Length < 7 || fields[6].Trim() == "") // checkng postal code is there or not
                            {
                                write_log.WriteLine(fileName.Replace(input_Folder_path, "") + " has error " + "Postal Code is blank at " + line_count.ToString());
                                records_discarded++;
                                Records_discarded_postal_Code++;
                                continue;
                            }
                            else
                            {
                                print_line = print_line + fields[6] + ",";

                            }


                            if (fields.Length >= 8) // checking in case file has only column less than count >= 
                            {
                                print_line = print_line + fields[7] + ",";

                            }
                            else { print_line = print_line + ","; }

                            if (fields.Length >= 9)// checking in case file has only column less than count >= 
                            {
                                print_line = print_line + fields[8] + ",";

                            }
                            else { print_line = print_line + ","; }

                            if (fields.Length >= 10)// checking in case file has only column less than count >= 
                            {
                                print_line = print_line + fields[9] +"," ;

                            }
                            else { print_line = print_line + ","; }



                            print_line = print_line + fileName.Replace(input_Folder_path, "").Substring(0, fileName.Replace(input_Folder_path, "").LastIndexOf("\\")) ;



                        }
                        if (print_line != "")
                        {
                            write_output.WriteLine(print_line);
                            Records_loaded++;
                        }

                    }
                }
            }

            catch (FileNotFoundException)
            {
                write_log.WriteLine("The file or directory cannot be found.");
            }
            catch (DirectoryNotFoundException)
            {
                write_log.WriteLine("The file or directory cannot be found.");
            }
            catch (DriveNotFoundException)
            {
                write_log.WriteLine("The drive specified in 'path' is invalid.");
            }
            catch (PathTooLongException)
            {
                write_log.WriteLine("'path' exceeds the maxium supported path length.");
            }
            catch (UnauthorizedAccessException)
            {
                write_log.WriteLine("You do not have permission to create this file.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                write_log.WriteLine("There is a sharing violation.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
            {
                write_log.WriteLine("The file already exists.");
            }
            catch (IOException e)
            {
                write_log.WriteLine($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }


            write_output.Close();

                write_log.Close();
            
    }


    }
}
